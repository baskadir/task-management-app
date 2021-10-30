using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Linq;
using TaskManagement.DataAccess.Context;

namespace TaskManagement.UI.TagHelpers
{
    [HtmlTargetElement("getPersonelInfo")]
    public class GetPersonelInfo : TagHelper
    {
        private readonly TaskContext _dbContext;
        public GetPersonelInfo(TaskContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int DutyId { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var user = _dbContext.Duties.Where(x => x.Id == DutyId).Select(x => x.AppUser).SingleOrDefault();
            output.Content.SetHtmlContent($"{user.FirstName} {user.LastName}");
        }
    }
}
