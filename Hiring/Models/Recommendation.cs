namespace Hiring.Models
{
    public class Recommendation
    {
        public int id { get; set; }
        public int recommenderEmployeeId { get;set; }
        public Employee recommenderEmployee { get; set; }
        public int recommendedEmployeeId { get; set; }
        public Employee recommendedEmployee { get; set; }
        public string description { get; set; }
    }
}
