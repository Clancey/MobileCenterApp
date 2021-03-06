﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Azure.Mobile;
using MobileCenterApi;
using SimpleAuth;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Web;

namespace MobileCenterApp
{
	public partial class App : Application
	{
		public App()
		{
			RegisterViewModels();
			BasicAuthApi.ShowAuthenticator = (IBasicAuthenicator obj) =>
			{
				Xamarin.Forms.Device.BeginInvokeOnMainThread(()=>MainPage.Navigation.PushModalAsync(new NavigationPage(new LoginPage(obj))));
			};
			InitializeComponent();
			// The root page of your application
			MainPage = SimpleIoC.GetPage(new MainPageViewModel());
		}

		void RegisterViewModels()
		{
			SimpleIoC.RegisterPage<AppListViewModel, AppListPage>();
			SimpleIoC.RegisterPage<CreateAppViewModel, CreateAppPage>();
			SimpleIoC.RegisterPage<MainPageViewModel, MainPage>();
			SimpleIoC.RegisterPage<GettingStartedViewModel, GettingStartedPage>();
			SimpleIoC.RegisterPage<BuildViewModel, BuildPage>();
			SimpleIoC.RegisterPage<TestViewModel,TestPage>();
			SimpleIoC.RegisterPage<DistributeViewModel, DistributePage>();
			SimpleIoC.RegisterPage<CrashesViewModel, CrashesPage>();
			SimpleIoC.RegisterPage<AnalyticsViewModel, AnalyticsPage>();
			SimpleIoC.RegisterPage<BranchDetailsViewModel, BranchDetailsPage>();
			SimpleIoC.RegisterPage<RepoListViewModel, RepoListPage>();
			SimpleIoC.RegisterPage<BuildLogViewModel, BuildLogPage>();
		}


		protected override void OnStart()
		{

		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
