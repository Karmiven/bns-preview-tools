namespace Xylia.Preview.Common.Attribute
{
	public class Side : System.Attribute
	{
		public Side() : this(Type.Both) { }

		public Side(Type sideType) => this.SideType = sideType;


		public Type SideType;



		public enum Type
		{
			Both,

			Client,

			Server,
		}
	}
}
