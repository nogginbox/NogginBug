﻿using System;

namespace NogginBug.MvcSite.ViewModels.Bugs
{
    public class BugViewModel : BugSummaryViewModel
    {
        public string Description { get; set; }

        public DateTime OpenedDate { get; set; }
    }
}