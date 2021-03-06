﻿using System;
using System.IO;
using System.Collections.Generic;

namespace Sproto
{
	public class SprotoTypeExtract
	{
		private MemoryStream buffer;
		private byte[] tmp;

		public SprotoTypeExtract () {
			this.buffer = new MemoryStream ();
			this.tmp = new byte[8] {0, 0, 0, 0, 0, 0, 0, 0};
		}

		private void write_ff(byte[] src, int offset, long pos, int n) {
			long cur_pos = this.buffer.Position;

			this.buffer.Seek (pos, SeekOrigin.Begin);

			this.buffer.WriteByte (0xff);
			this.buffer.WriteByte ((byte)(n - 1));
			this.buffer.Write (src, offset, n * 8);

			this.buffer.Seek (cur_pos, SeekOrigin.Begin);
		}

		private int pack_seg(byte[] src, long offset,  int ff_n) {
			byte header = 0;
			int notzero = 0;

			long header_pos = this.buffer.Position;
			this.buffer.Seek (1, SeekOrigin.Current);

			for (int i = 0; i < 8; i++) {
				if (src [offset + i] != 0) {
					notzero++;
					header |= (byte)(1 << i);
					this.buffer.WriteByte (src[offset + i]);
				}
			}

			if ((notzero == 7 || notzero == 6) &&ff_n > 0) {
				notzero = 8;
			}
			if (notzero == 8) {
				if (ff_n > 0) {
					this.buffer.Seek (header_pos, SeekOrigin.Begin);
					return 8;
				} else {
					this.buffer.Seek (header_pos, SeekOrigin.Begin);
					return 10;
				}
			}

			this.buffer.Seek (header_pos, SeekOrigin.Begin);
			this.buffer.WriteByte (header);
			this.buffer.Seek (header_pos, SeekOrigin.Begin);
			return notzero + 1;
		}


		public byte[] pack (byte[] data) {
			this.clear ();

			byte[] ff_src = null;
			int    ff_srcstart = 0;
			long   ff_desstart = 0;

			int ff_n = 0;

			byte[] src = data;
			int offset = 0;

			int srcsz = data.Length;
			for (int i = 0; i < srcsz; i += 8) {
				offset = i;

				int padding = i + 8 - srcsz;
				if (padding > 0) {
					for (int j = 0; j < 8 - padding; j++) {
						this.tmp [j] = src [i + j];
					}
					for (int j = 0; j < padding; j++) {
						this.tmp [7 - j] = 0;
					}

					src = this.tmp;
					offset = 0;
				}

				int n = this.pack_seg (src, offset,  ff_n);
				if (n == 10) {
					// first FF
					ff_src = src;
					ff_srcstart = offset;
					ff_desstart = this.buffer.Position;
					ff_n = 1;
				} else if (n == 8 && ff_n > 0) {
					++ff_n;
					if (ff_n == 256) {
						this.write_ff (ff_src, ff_srcstart, ff_desstart, 256);
						ff_n = 0;
					}
				} else {
					if (ff_n > 0) {
						this.write_ff (ff_src, ff_srcstart, ff_desstart, ff_n);
						ff_n = 0;
					}
				}

				this.buffer.Seek (n, SeekOrigin.Current);
			}

			if (ff_n > 0) {
				this.write_ff (ff_src, ff_srcstart, ff_desstart, ff_n);
			}

			long maxsz = (data.LongLength + 2047) / 2048 * 2 + data.LongLength;
			if (maxsz < this.buffer.Position) {
				SprotoTypeSize.error ("packing error, return size="+this.buffer.Position);
			}

			byte[] pack_buffer = new byte[this.buffer.Position];
			this.buffer.Seek (0, SeekOrigin.Begin);
			this.buffer.Read (pack_buffer, 0, pack_buffer.Length);

			return pack_buffer;
		}


		public byte[] unpack (byte[] data) {
			this.clear ();

			int srcsz = data.Length;

			while (srcsz > 0) {
				byte header = data [data.Length - srcsz];
				--srcsz;

				if (header == 0xff) {
					if (srcsz < 0) {
						SprotoTypeSize.error ("invalid unpack stream.");
					}

					int n = (data [data.Length - srcsz] + 1) * 8;

					if (srcsz < n + 1) {
						SprotoTypeSize.error ("invalid unpack stream.");
					}

					this.buffer.Write (data, data.Length - srcsz + 1, n);
					srcsz -= n + 1;
				} else {
					for (int i = 0; i < 8; i++) {
						int nz = (header >> i) & 1;
						if (nz == 1) {
							if (srcsz < 0) {
								SprotoTypeSize.error ("invalid unpack stream.");
							}

							this.buffer.WriteByte (data [data.Length - srcsz]);
							--srcsz;
						} else {
							this.buffer.WriteByte (0);
						}
					}
				}
			}

			byte[] unpack_data = new byte[this.buffer.Position];
			this.buffer.Seek (0, SeekOrigin.Begin);

			this.buffer.Read (unpack_data, 0, unpack_data.Length);
			return unpack_data;;
		}



		public void clear() {
			this.buffer.Seek (0, SeekOrigin.Begin);

			for (int i = 0; i < this.tmp.Length; i++) {
				this.tmp [i] = 0;
			}
		}


	}
}

