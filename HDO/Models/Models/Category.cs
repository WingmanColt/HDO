using Microsoft.AspNetCore.Identity;

namespace Models
{
    public class Category : BaseModel
    {
        public string Title { get; set; }
        public string SysName { get; set; }
        public string Icon { get; set; }
    }
}
