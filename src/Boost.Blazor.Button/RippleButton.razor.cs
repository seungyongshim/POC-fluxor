using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Boost.Blazor.Button
{
    public partial class RippleButton
    {
            [Parameter]
            public RenderFragment ChildContent { get; set; }

            [Parameter(CaptureUnmatchedValues = true)]
            public Dictionary<string, object> AdditionalAttributes { get; set; }

            public MarkupString RippleMarkup { get; set; }

            private void OnClick(MouseEventArgs mouseEventArgs)
            {
                var guid = Guid.NewGuid().ToString();
                var x = mouseEventArgs.OffsetX;
                var y = mouseEventArgs.OffsetY;
                RippleMarkup = (MarkupString)@$"<div {guid} class=""ripple"" style=""top:{y}px;left:{x}px"" btn-ripple/>";
            }
    }
}
