using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TBH.DND.Android.Models;
using TBH.DND.Android.Services;

namespace TBH.DND.Android.ViewModels
{
    internal class AbilityAllViewModel
    {
        readonly AbilityDatabase db;

        public ObservableCollection<Ability> Abilities { get; } = new ObservableCollection<Ability>();

        public AbilityAllViewModel(AbilityDatabase database)
        {
            db = database;
        }

        public async Task LoadAsync()
        {
            Abilities.Clear();
            var items = await db.GetAllAbilitiesAsync();
            var abilities = items.OrderBy(x => x.Name);
            foreach (var a in abilities)
            {
                Abilities.Add(a);
            }
        }

        public async Task SaveAbilityAsync(Ability a)
        {
            await db.SaveAbilityAsync(a);
        }
        public async Task DeleteAbilityAsync(Ability a)
        {
            await db.DeleteAbilityAsync(a.Id);
            Abilities.Remove(a);
        }
    }
}
