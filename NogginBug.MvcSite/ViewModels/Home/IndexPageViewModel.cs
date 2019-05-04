﻿using NogginBug.MvcSite.ViewModels.Shared;
using System.Collections.Generic;

namespace NogginBug.MvcSite.ViewModels.Home
{
    public class IndexPageViewModel : BasePageViewModel
    {
        public IndexPageViewModel(string title) : base(title) {}

        public IList<BugViewModel> Bugs { get; set; }
    }
}