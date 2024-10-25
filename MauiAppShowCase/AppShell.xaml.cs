﻿using MauiAppShowCase.View;

namespace MauiAppShowCase
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

		//nameof(DetailsPage) == "DetailsPage"
		Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
        Routing.RegisterRoute(nameof(LoginPage),typeof(LoginPage));
        }
    }
}