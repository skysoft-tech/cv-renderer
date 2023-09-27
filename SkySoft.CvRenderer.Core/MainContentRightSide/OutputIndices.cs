using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Core.Models;
using WebApplicationPdf.TitlePage;

namespace WebApplicationPdf.MainContentRightSide
{
    public class OutputIndices : IComponent
    {
        public CvModel cvModel { get; }
        public int number { get; }
        
        public OutputIndices(CvModel valueList, int EvenUneven)
        {
            CvModel cvModel = valueList;
            number = EvenUneven;
        }

        public void Compose(IContainer container)
        {
            //for (int a = 0; a < skill.Count; a++)
            //{
            //if (a % 2 == number)
            //{
            for (int a = 0; a < cvModel.Skills.Count; a++)
            {
                container.Row(row =>
                {
                    row.RelativeItem()
                   .PaddingRight(42)
                   .Component(new Skills(cvModel.Skills[a]));

                    row.RelativeItem()
                    .PaddingRight(42)
                    .Component(new Skills(cvModel.Skills[a]));
                });
            } 
        }
    }
}
