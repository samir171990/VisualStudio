﻿using GitHub.Services;
using GitHub.UI;
using System;
using System.Diagnostics;
using GitHub.Extensions;
using GitHub.Logging;

namespace GitHub.VisualStudio.Menus
{
    public class CreateGist : MenuBase, IDynamicMenuHandler
    {
        readonly Lazy<IDialogService> dialogService;
        readonly Lazy<ISelectedTextProvider> selectedTextProvider;
        ISelectedTextProvider SelectedTextProvider => selectedTextProvider.Value;

        public CreateGist(IGitHubServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            Guard.ArgumentNotNull(serviceProvider, nameof(serviceProvider));

            dialogService = new Lazy<IDialogService>(() => ServiceProvider.TryGetService<IDialogService>());
            selectedTextProvider = new Lazy<ISelectedTextProvider>(() => ServiceProvider.TryGetService<ISelectedTextProvider>());
        }

        public Guid Guid { get { return Guids.guidContextMenuSet; } }
        public int CmdId { get { return PkgCmdIDList.createGistCommand; } }

        public bool CanShow()
        {
            Log.Assert(SelectedTextProvider != null, "Could not get an instance of ISelectedTextProvider");
            return !String.IsNullOrWhiteSpace(SelectedTextProvider?.GetSelectedText());
        }

        public void Activate(object data)
        {
            dialogService.Value?.ShowCreateGist();
        }
    }
}
