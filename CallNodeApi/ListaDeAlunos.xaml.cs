using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CallNodeApi
{
	public partial class ListaDeAlunos : ContentPage
	{
		public ListaDeAlunos ()
		{
			InitializeComponent ();


		}

		void lvAluno_Sl (object sender, SelectedItemChangedEventArgs e)
		{
			var aluno = e.SelectedItem as Aluno;
			WebServiceBase<Aluno>.RequestAsync ("alunos/" + aluno._id, RequestType.Delete);


			WebServiceBase<List<Aluno>>.RequestAsync ("alunos").ContinueWith (t => {

				Device.BeginInvokeOnMainThread (() => {
					lstAlunos.ItemsSource = t.Result;
				});
			});
		}

		void navegar (object sender, EventArgs e)
		{
			Navigation.PushAsync (new InserirAluno ());
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			WebServiceBase<List<Aluno>>.RequestAsync ("alunos").ContinueWith (t => {

				Device.BeginInvokeOnMainThread (() => {
					lstAlunos.ItemsSource = t.Result;
				});
			});
		}
	}
}

