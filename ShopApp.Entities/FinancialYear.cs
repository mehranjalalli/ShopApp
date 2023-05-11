using System;

namespace ShopApp.Entities
{
    [DataLayer.Table("dbo","FinancialYears")]
    public class FinancialYear
    {
        [DataLayer.PrimaryKey]
        [DataLayer.ComputedColumn]
        public int Id { get; set; }
        public int CorporationId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public bool IsClosed { get; set; }
        public DateTime? CloseDate { get; set; }
        public int? ClosedByUserId { get; set; }
        public bool Deleted { get; set; }
        public DateTime? DeleteDate { get; set; }
        public int? DeletedByUserId { get; set; }
    }
}
