using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using testApp1.Back_end;
using testApp1.Back_end.Entities;

namespace testApp1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> logger;
        private readonly ApplicationDbContext dbContext;

        public IndexModel(ApplicationDbContext dbContext, ILogger<IndexModel> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }

        [BindProperty]
        public string? MouseTrackingData { get; set; }

        public void OnPost()
        {
            if (this.MouseTrackingData == null)
            {
                return;
            }

            var mouseTrackingParsedData = new List<MousePoint>();

            mouseTrackingParsedData = this.MouseTrackingData.Split(";").Where(mtd => !string.IsNullOrEmpty(mtd)).Select(mtd =>
            {
                var splittedData = mtd.Split(",");

                return new MousePoint()
                {
                    xCoord = int.Parse(splittedData[0]),
                    yCoord = int.Parse(splittedData[1]),
                    TimeStamp = DateTime.Parse(splittedData[2]),
                };
            }).ToList();

            if (!mouseTrackingParsedData.Any())
            {
                return;
            }

            this.dbContext.MovementDatas.Add(new MovementData()
            {
                TrackingData = mouseTrackingParsedData,
            });

            this.dbContext.SaveChanges();

            return;
        }
    }
}
