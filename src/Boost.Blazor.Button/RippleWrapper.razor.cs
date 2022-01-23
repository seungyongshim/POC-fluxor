using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Boost.Blazor.Button
{
    public partial class RippleWrapper
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public bool Enabled { get; set; } = true;

        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> AdditionalAttributes { get; set; }

        public MarkupString RippleMarkup { get; set; }

        [Parameter]
        public string Color { get; set; } = "#fff";

        private void OnClick(MouseEventArgs mouseEventArgs)
        {
            if (Enabled is not true)
            {
                return;
            }

            var guid = Guid.NewGuid().ToString();
            var x = mouseEventArgs.OffsetX;
            var y = mouseEventArgs.OffsetY;
            RippleMarkup = (MarkupString)@$"<div {guid} class=""ripple"" style=""top:{y}px;left:{x}px;background:{Color}"" ripplewrapper1/>";
        }
    }
}
