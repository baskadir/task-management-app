using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Linq;
using TaskManagement.DataAccess.Context;

namespace TaskManagement.UI.TagHelpers
{
    [HtmlTargetElement("getStatusInfo")]
    public class GetStatusInfo : TagHelper
    {
        private readonly TaskContext _dbContext;
        public GetStatusInfo(TaskContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int DutyId { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var status = _dbContext.Duties.Where(x => x.Id == DutyId).Select(x => x.Status).SingleOrDefault();
            output.Content.SetHtmlContent(status.Definition);
        }
    }
}
