using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CallNodeApi
{
	public partial class InserirAluno : ContentPage
	{
		public InserirAluno ()
		{
			InitializeComponent ();


		}

		void btnInserir (object sender, EventArgs e){
			var aluno = new Aluno (){ 
				nome = eNome.Text,
				email = eEmail.Text
			};

			WebServiceBase<Aluno>.RequestAsync ("alunos", RequestType.Post, aluno);
		}
	}
}

