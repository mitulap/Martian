//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
namespace AssemblyCSharp
{
	public class MainMenu
	{

		MenuManager menuManager;
		private string menuCommand;

		public MainMenu ()
		{

		}

		public void PlayGame(MenuManager menuManager){
			menuManager.ToggleMenu ();
		}

		public void QuitGame(MenuManager menuManager){
			menuManager.QuitGameMethod ();
		}

	}
}

