// Generated by sprotodump. DO NOT EDIT!
// source: ../gen_example/TestRpc.sproto

using System;
using Sproto;
using System.Collections.Generic;

namespace TestRpcType{ 
	public class blackhole : SprotoTypeBase {
		private static int max_field_count = 0;
		
		public class request : SprotoTypeBase {
			private static int max_field_count = 0;
			
			
			public request () : base(max_field_count) {}

			public request (byte[] buffer) : base(max_field_count, buffer) {
				this.decode ();
			}

			protected override void decode () {
				int tag = -1;
				while (-1 != (tag = base.deserialize.read_tag ())) {
					switch (tag) {
					default:
						base.deserialize.read_unknow_data ();
						break;
					}
				}
			}

			public override byte[] encode () {
				byte[] buffer = base.serialize.encode ();
				base.serialize.clear ();

				return buffer;
			}
		}


		
		public blackhole () : base(max_field_count) {}

		public blackhole (byte[] buffer) : base(max_field_count, buffer) {
			this.decode ();
		}

		protected override void decode () {
			int tag = -1;
			while (-1 != (tag = base.deserialize.read_tag ())) {
				switch (tag) {
				default:
					base.deserialize.read_unknow_data ();
					break;
				}
			}
		}

		public override byte[] encode () {
			byte[] buffer = base.serialize.encode ();
			base.serialize.clear ();

			return buffer;
		}
	}


	public class foo : SprotoTypeBase {
		private static int max_field_count = 1;
		
		public class response : SprotoTypeBase {
			private static int max_field_count = 1;
			
			
			private bool _ok; // tag 0
			public bool ok {
				get { return _ok; }
				set { base.has_field.set_field (0, true); _ok = value; }
			}

			public response () : base(max_field_count) {}

			public response (byte[] buffer) : base(max_field_count, buffer) {
				this.decode ();
			}

			protected override void decode () {
				int tag = -1;
				while (-1 != (tag = base.deserialize.read_tag ())) {
					switch (tag) {
					case 0:
						this.ok = base.deserialize.read_boolean ();
						break;
					default:
						base.deserialize.read_unknow_data ();
						break;
					}
				}
			}

			public override byte[] encode () {
				if (base.has_field.has_field (0)) {
					base.serialize.write_boolean (this.ok, 0);
				}

				byte[] buffer = base.serialize.encode ();
				base.serialize.clear ();

				return buffer;
			}
		}


		
		private bool _ok; // tag 0
		public bool ok {
			get { return _ok; }
			set { base.has_field.set_field (0, true); _ok = value; }
		}

		public foo () : base(max_field_count) {}

		public foo (byte[] buffer) : base(max_field_count, buffer) {
			this.decode ();
		}

		protected override void decode () {
			int tag = -1;
			while (-1 != (tag = base.deserialize.read_tag ())) {
				switch (tag) {
				case 0:
					this.ok = base.deserialize.read_boolean ();
					break;
				default:
					base.deserialize.read_unknow_data ();
					break;
				}
			}
		}

		public override byte[] encode () {
			if (base.has_field.has_field (0)) {
				base.serialize.write_boolean (this.ok, 0);
			}

			byte[] buffer = base.serialize.encode ();
			base.serialize.clear ();

			return buffer;
		}
	}


	public class foobar : SprotoTypeBase {
		private static int max_field_count = 1;
		
		public class request : SprotoTypeBase {
			private static int max_field_count = 1;
			
			
			private string _what; // tag 0
			public string what {
				get { return _what; }
				set { base.has_field.set_field (0, true); _what = value; }
			}

			public request () : base(max_field_count) {}

			public request (byte[] buffer) : base(max_field_count, buffer) {
				this.decode ();
			}

			protected override void decode () {
				int tag = -1;
				while (-1 != (tag = base.deserialize.read_tag ())) {
					switch (tag) {
					case 0:
						this.what = base.deserialize.read_string ();
						break;
					default:
						base.deserialize.read_unknow_data ();
						break;
					}
				}
			}

			public override byte[] encode () {
				if (base.has_field.has_field (0)) {
					base.serialize.write_string (this.what, 0);
				}

				byte[] buffer = base.serialize.encode ();
				base.serialize.clear ();

				return buffer;
			}
		}


		public class response : SprotoTypeBase {
			private static int max_field_count = 1;
			
			
			private bool _ok; // tag 0
			public bool ok {
				get { return _ok; }
				set { base.has_field.set_field (0, true); _ok = value; }
			}

			public response () : base(max_field_count) {}

			public response (byte[] buffer) : base(max_field_count, buffer) {
				this.decode ();
			}

			protected override void decode () {
				int tag = -1;
				while (-1 != (tag = base.deserialize.read_tag ())) {
					switch (tag) {
					case 0:
						this.ok = base.deserialize.read_boolean ();
						break;
					default:
						base.deserialize.read_unknow_data ();
						break;
					}
				}
			}

			public override byte[] encode () {
				if (base.has_field.has_field (0)) {
					base.serialize.write_boolean (this.ok, 0);
				}

				byte[] buffer = base.serialize.encode ();
				base.serialize.clear ();

				return buffer;
			}
		}


		
		private string _what; // tag 0
		public string what {
			get { return _what; }
			set { base.has_field.set_field (0, true); _what = value; }
		}

		public foobar () : base(max_field_count) {}

		public foobar (byte[] buffer) : base(max_field_count, buffer) {
			this.decode ();
		}

		protected override void decode () {
			int tag = -1;
			while (-1 != (tag = base.deserialize.read_tag ())) {
				switch (tag) {
				case 0:
					this.what = base.deserialize.read_string ();
					break;
				default:
					base.deserialize.read_unknow_data ();
					break;
				}
			}
		}

		public override byte[] encode () {
			if (base.has_field.has_field (0)) {
				base.serialize.write_string (this.what, 0);
			}

			byte[] buffer = base.serialize.encode ();
			base.serialize.clear ();

			return buffer;
		}
	}


	public class package : SprotoTypeBase {
		private static int max_field_count = 3;
		
		
		private Int64 _type; // tag 0
		public Int64 type {
			get { return _type; }
			set { base.has_field.set_field (0, true); _type = value; }
		}

		private Int64 _session; // tag 1
		public Int64 session {
			get { return _session; }
			set { base.has_field.set_field (1, true); _session = value; }
		}

		public package () : base(max_field_count) {}

		public package (byte[] buffer) : base(max_field_count, buffer) {
			this.decode ();
		}

		protected override void decode () {
			int tag = -1;
			while (-1 != (tag = base.deserialize.read_tag ())) {
				switch (tag) {
				case 0:
					this.type = base.deserialize.read_integer ();
					break;
				case 1:
					this.session = base.deserialize.read_integer ();
					break;
				default:
					base.deserialize.read_unknow_data ();
					break;
				}
			}
		}

		public override byte[] encode () {
			if (base.has_field.has_field (0)) {
				base.serialize.write_integer (this.type, 0);
			}

			if (base.has_field.has_field (1)) {
				base.serialize.write_integer (this.session, 1);
			}

			byte[] buffer = base.serialize.encode ();
			base.serialize.clear ();

			return buffer;
		}
	}


}


namespace TestRpcProtocol{ 
	public class bar {
		public const int tag = 3;
	}

	public class blackhole {
		public const int tag = 4;
		public TestRpcType.blackhole.request request;
	}

	public class foo {
		public const int tag = 2;
		public TestRpcType.foo.response response;
	}

	public class foobar {
		public const int tag = 1;
		public TestRpcType.foobar.request request;
		public TestRpcType.foobar.response response;
	}

}

