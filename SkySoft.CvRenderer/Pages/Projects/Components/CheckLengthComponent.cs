using QuestPDF.Elements;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace SkySoft.CvRenderer.Pages.Projects.Components
{
    public struct FibonacciHeaderState
    {
        public int Previous { get; set; }
        public int Current { get; set; }
    }

    public class FibonacciHeader : IDynamicComponent<FibonacciHeaderState>
    {
        public FibonacciHeaderState State { get; set; }

        public static readonly string[] ColorsTable =
        {
            Colors.Red.Lighten2,
            Colors.Orange.Lighten2,
            Colors.Green.Lighten2,
         };

        public FibonacciHeader(int previous, int current)
        {
            State = new FibonacciHeaderState
            {
                Previous = previous,
                Current = current
            };
        }

        public DynamicComponentComposeResult Compose(DynamicContext context)
        {
            var content = context.CreateElement(container =>
            {
                var colorIndex = State.Current % ColorsTable.Length;
                var color = ColorsTable[colorIndex];

                var ratio = (float)State.Current / State.Previous;

                container
                    .Background(color)
                    .Height(50)
                    .AlignMiddle()
                    .AlignCenter()
                    .Text($"{State.Current} / {State.Previous} = {ratio:N5}");
            });

            // please note that the code assigns NEW state, instead of mutating the existing one
            State = new FibonacciHeaderState
            {
                Previous = State.Current,
                Current = State.Previous + State.Current
            };

            return new DynamicComponentComposeResult
            {
                Content = content,
                HasMoreContent = false // each page has its own content
            };
        }
    }
}
