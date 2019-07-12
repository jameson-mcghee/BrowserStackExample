using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserStackIntegration
{
    public class TopicsPage : WatchPage
    {
        public TopicsPage(string profile, string device) : base(profile, device) { }

        public async Task AddTopicsToYourFavoriteTopicsSection()
        {
            //TODO: Add Steps to add topics to the 'Your Favorite Topics' section
        }

        public async Task RemoveFavoriteTopicsFromDiscoverTopicsSection()
        {
            //TODO: Add Steps to remove topics from the 'Discover Topics' section
        }

        public async Task RemoveFavoriteTopicsFromYourFavoriteTopicsSection()
        {
            //TODO: Add Steps to remove topics from the 'Your Favorite Topics' section
        }

        public async Task OpenATopicFrontPageFromDiscoverTopicsSection()
        {
            //TODO: Add steps to open a topic front page from the 'Discover Topics' section
        }

        public async Task OpenATopicFrontPageFromYourFavoriteTopicsSection()
        {
            //TODO: Add steps to open a topic front page from the 'Your Favorite Topics' section
        }

        public async Task SearchForATopic()
        {
            //TODO: Add steps to search for a topic
        }

        public async Task ManageTopicAlertsAndNotifications()
        {
            //TODO: Add steps to click the 'Manage Topic Alerts and Notifications' button
        }
    }
}
