﻿using System;
using Microsoft.AspNetCore.Components;

namespace MyApp.Components.Message
{
    public partial class MessageView : ComponentBase
    {
        [Parameter]
        public string Icon { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public string Message { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        public MessageView()
        {
            Icon = string.Empty;
            Title = string.Empty;
            Message = string.Empty;
        }
    }
}
