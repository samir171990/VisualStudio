﻿using System;
using System.Threading.Tasks;
using GitHub.Models;

namespace GitHub.ViewModels.GitHubPane
{
    /// <summary>
    /// The view model for the GitHub Pane.
    /// </summary>
    public interface INewGitHubPaneViewModel
    {
        /// <summary>
        /// Gets the connection to the current repository.
        /// </summary>
        IConnection Connection { get; }

        /// <summary>
        /// Gets the content to display in the GitHub pane.
        /// </summary>
        INewViewModel Content { get; }

        /// <summary>
        /// Gets the local repository.
        /// </summary>
        ILocalRepositoryModel LocalRepository { get; }

        /// <summary>
        /// Gets the title to display in the GitHub pane header.
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Initializes the view model.
        /// </summary>
        Task InitializeAsync();

        /// <summary>
        /// Shows the pull reqest list in the GitHub pane.
        /// </summary>
        Task ShowPullRequests();

        /// <summary>
        /// Shows the details for a pull request in the GitHub pane.
        /// </summary>
        /// <param name="owner">The repository owner.</param>
        /// <param name="repo">The repository name.</param>
        /// <param name="number">The pull rqeuest number.</param>
        Task ShowPullRequest(string owner, string repo, int number);
    }
}