namespace Sota.Dashboard.DataAccess.Models.Raw
{
	public class DbFilter
	{
		public long Id { get; set; }
		public string FilterCode { get; set; }
		public string FilterName { get; set; }
		public string Text { get; set; }
		public bool IsActualRow { get; set; }
		public bool IsActualFilter { get; set; }
		public int Ord { get; set; }
	}
}
