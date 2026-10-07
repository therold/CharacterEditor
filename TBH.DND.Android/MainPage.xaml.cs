using Microsoft.Maui.Controls;
using TBH.DND.Android.ViewModels;
using TBH.DND.Android.Models;
using TBH.DND.Android.Services;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Maui.ApplicationModel;

namespace TBH.DND.Android
{
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel? vm;
        private CharacterDatabase? characterDb;
        private SpellDatabase? db;
        private AbilityDatabase? abilityDb;
        private FeatDatabase? featDb;
        private TraitDatabase? traitDb;

        public MainPage()
        {
            InitializeComponent();
            vm = App.Services?.GetService(typeof(MainPageViewModel)) as MainPageViewModel;
            db = App.Services?.GetService(typeof(SpellDatabase)) as SpellDatabase;
            abilityDb = App.Services?.GetService(typeof(AbilityDatabase)) as AbilityDatabase;
            featDb = App.Services?.GetService(typeof(FeatDatabase)) as FeatDatabase;
            traitDb = App.Services?.GetService(typeof(TraitDatabase)) as TraitDatabase;
            characterDb = App.Services?.GetService(typeof(CharacterDatabase)) as CharacterDatabase;
            BindingContext = vm;
            Shell.SetNavBarIsVisible(this, false);
        }

        private void FixSpellSlotVisibility(int level, int amount)
        {
            if (amount < 1)
            {
                for (int i = 5; i > 0; i--)
                {
                    var checkBox = this.FindByName<CheckBox>($"checkBoxSpellSlots{level}Level{i}");
                    if (checkBox != null)
                        checkBox.IsVisible = false;
                }
                var label = this.FindByName<Label>($"labelSpellSlot{level}Level");
                if (label != null)
                    label.IsVisible = false;
                var buttonRemove = this.FindByName<Button>($"buttonRemoveSpellSlot{level}Level");
                if (buttonRemove != null)
                    buttonRemove.IsVisible = false;
                var buttonAdd = this.FindByName<Button>($"buttonAddSpellSlot{level}Level");
                if (buttonAdd != null)
                    buttonAdd.IsVisible = false;
            }
            else
            {
                var label = this.FindByName<Label>($"labelSpellSlot{level}Level");
                if (label != null)
                    label.IsVisible = true;
                var buttonRemove = this.FindByName<Button>($"buttonRemoveSpellSlot{level}Level");
                if (buttonRemove != null)
                    buttonRemove.IsVisible = true;
                var buttonAdd = this.FindByName<Button>($"buttonAddSpellSlot{level}Level");
                if (buttonAdd != null)
                    buttonAdd.IsVisible = true;
                for (int i = 5; i > 0; i--)
                {
                    var checkBox = this.FindByName<CheckBox>($"checkBoxSpellSlots{level}Level{i}");
                    if (checkBox != null)
                    {
                        if (i > amount)
                            checkBox.IsVisible = false;
                        else
                            checkBox.IsVisible = true;
                    }
                }
            }
        }

        private void FixSpellSlotChecked(int level, int amount, int max)
        {
            for (int i = max; i > 0; i--)
            {
                var checkBox = this.FindByName<CheckBox>($"checkBoxSpellSlots{level}Level{i}");
                if (checkBox != null)
                {
                    if (i > amount)
                    {
                        checkBox.IsChecked = false;
                        checkBox.IsEnabled = false;
                    }
                    else
                    {
                        checkBox.IsChecked = true;
                        checkBox.IsEnabled = true;
                    }
                }
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (vm != null)
            {
                await vm.LoadAsync();
                FixSpellSlotVisibility(1, vm.Character.SpellSlotsFirstLevel);
                FixSpellSlotVisibility(2, vm.Character.SpellSlotsSecondLevel);
                FixSpellSlotVisibility(3, vm.Character.SpellSlotsThirdLevel);
                FixSpellSlotVisibility(4, vm.Character.SpellSlotsFourthLevel);
                FixSpellSlotVisibility(5, vm.Character.SpellSlotsFifthLevel);
                FixSpellSlotVisibility(6, vm.Character.SpellSlotsSixthLevel);
                FixSpellSlotVisibility(7, vm.Character.SpellSlotsSeventhLevel);
                FixSpellSlotVisibility(8, vm.Character.SpellSlotsEighthLevel);
                FixSpellSlotVisibility(9, vm.Character.SpellSlotsNinthLevel);

                FixSpellSlotChecked(1, vm.Character.SpellSlotsFirstLevelCurrent, vm.Character.SpellSlotsFirstLevel);
                FixSpellSlotChecked(2, vm.Character.SpellSlotsSecondLevelCurrent, vm.Character.SpellSlotsSecondLevel);
                FixSpellSlotChecked(3, vm.Character.SpellSlotsThirdLevelCurrent, vm.Character.SpellSlotsThirdLevel);
                FixSpellSlotChecked(4, vm.Character.SpellSlotsFourthLevelCurrent, vm.Character.SpellSlotsFourthLevel);
                FixSpellSlotChecked(5, vm.Character.SpellSlotsFifthLevelCurrent, vm.Character.SpellSlotsFifthLevel);
                FixSpellSlotChecked(6, vm.Character.SpellSlotsSixthLevelCurrent, vm.Character.SpellSlotsSixthLevel);
                FixSpellSlotChecked(7, vm.Character.SpellSlotsSeventhLevelCurrent, vm.Character.SpellSlotsSeventhLevel);
                FixSpellSlotChecked(8, vm.Character.SpellSlotsEighthLevelCurrent, vm.Character.SpellSlotsEighthLevel);
                FixSpellSlotChecked(9, vm.Character.SpellSlotsNinthLevelCurrent, vm.Character.SpellSlotsNinthLevel);
                //characterDb.SaveCharacterAsync(vm.Character);
            }
        }

        private async void OnNullTapped(object? sender, EventArgs e)
        {
            // do nothing
        }
        private async void OnItemTapped(object? sender, EventArgs e)
        {
            var ve = sender as VisualElement;
            if (ve != null)
            {
                if (ve.BindingContext is Spell s)
                {
                    s.IsExpanded = !s.IsExpanded;
                }
                else if (ve.BindingContext is Ability a)
                {
                    a.IsExpanded = !a.IsExpanded;
                }
                else if (ve.BindingContext is Feat f)
                {
                    f.IsExpanded = !f.IsExpanded;
                }
                else if (ve.BindingContext is Trait t)
                {
                    t.IsExpanded = !t.IsExpanded;
                }
            }
        }

        private async void OnEditSwipeItemInvoked(object? sender, EventArgs e)
        {
            if (sender is SwipeItem si)
            {
                if (si.CommandParameter is Spell s)
                {
                    await Shell.Current.GoToAsync($"SpellEditorPage?id={s.Id}");
                }
                else if (si.CommandParameter is Ability a)
                {
                    await Shell.Current.GoToAsync($"AbilityEditorPage?id={a.Id}");
                }
                else if (si.CommandParameter is Feat f)
                {
                    await Shell.Current.GoToAsync($"FeatEditorPage?id={f.Id}");
                }
                else if (si.CommandParameter is Trait t)
                {
                    await Shell.Current.GoToAsync($"TraitEditorPage?id={t.Id}");
                }
            }
        }

        private async void OnDeleteSwipeItemInvoked(object? sender, EventArgs e)
        {
            var si = sender as SwipeItem;
            if (si != null)
            {
                if (si.CommandParameter is Spell s && db != null)
                {
                    var ok = await DisplayAlertAsync("Delete", $"Delete '{s.Name}'?", "Delete", "Cancel");
                    if (!ok)
                        return;
                    await db.DeleteSpellAsync(s.Id);
                }
                else if (si.CommandParameter is Ability a && abilityDb != null)
                {
                    var ok = await DisplayAlertAsync("Delete", $"Delete '{a.Name}'?", "Delete", "Cancel");
                    if (!ok)
                        return;
                    await abilityDb.DeleteAbilityAsync(a.Id);
                }
                else if (si.CommandParameter is Feat f && featDb != null)
                {
                    var ok = await DisplayAlertAsync("Delete", $"Delete '{f.Name}'?", "Delete", "Cancel");
                    if (!ok)
                        return;
                    await featDb.DeleteFeatAsync(f.Id);
                }
                else if (si.CommandParameter is Trait t && traitDb != null)
                {
                    var ok = await DisplayAlertAsync("Delete", $"Delete '{t.Name}'?", "Delete", "Cancel");
                    if (!ok)
                        return;
                    await traitDb.DeleteTraitAsync(t.Id);
                }

                if (vm != null)
                    await vm.LoadAsync();
            }
            
        }
        
        private async void OnEditCharacterlicked(object? sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"CharacterEditorPage?id={vm.Character.Id}");
        }
        private async void OnSpellsAllMenuClicked(object? sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("SpellAllPage");
        }

        private async void OnSpellSlotRemoveClicked(object? sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is string levelParam)
            {
                if (int.TryParse(levelParam, out int level) && vm != null)
                {
                    switch (level)
                    {
                        case 1:
                            if (vm.Character.SpellSlotsFirstLevelCurrent > 0)
                            {
                                vm.Character.SpellSlotsFirstLevelCurrent--;
                                FixSpellSlotChecked(level, vm.Character.SpellSlotsFirstLevelCurrent, vm.Character.SpellSlotsFirstLevel);
                            }
                            break;
                        case 2:
                            if (vm.Character.SpellSlotsSecondLevelCurrent > 0)
                            {
                                vm.Character.SpellSlotsSecondLevelCurrent--;
                                FixSpellSlotChecked(level, vm.Character.SpellSlotsSecondLevelCurrent, vm.Character.SpellSlotsSecondLevel);
                            }
                            break;
                        case 3:
                            if (vm.Character.SpellSlotsThirdLevelCurrent > 0)
                            {
                                vm.Character.SpellSlotsThirdLevelCurrent--;
                                FixSpellSlotChecked(level, vm.Character.SpellSlotsThirdLevelCurrent, vm.Character.SpellSlotsThirdLevel);
                            }
                            break;
                        case 4:
                            if (vm.Character.SpellSlotsFourthLevelCurrent > 0)
                            {
                                vm.Character.SpellSlotsFourthLevelCurrent--;
                                FixSpellSlotChecked(level, vm.Character.SpellSlotsFourthLevelCurrent, vm.Character.SpellSlotsFourthLevel);
                            }
                            break;
                        case 5:
                            if (vm.Character.SpellSlotsFifthLevelCurrent > 0)
                            {
                                vm.Character.SpellSlotsFifthLevelCurrent--;
                                FixSpellSlotChecked(level, vm.Character.SpellSlotsFifthLevelCurrent, vm.Character.SpellSlotsFifthLevel);
                            }
                            break;
                        case 6:
                            if (vm.Character.SpellSlotsSixthLevelCurrent > 0)
                            {
                                vm.Character.SpellSlotsSixthLevelCurrent--;
                                FixSpellSlotChecked(level, vm.Character.SpellSlotsSixthLevelCurrent, vm.Character.SpellSlotsSixthLevel);
                            }
                            break;
                        case 7:
                            if (vm.Character.SpellSlotsSeventhLevelCurrent > 0)
                            {
                                vm.Character.SpellSlotsSeventhLevelCurrent--;
                                FixSpellSlotChecked(level, vm.Character.SpellSlotsSeventhLevelCurrent, vm.Character.SpellSlotsSeventhLevel);
                            }
                            break;
                        case 8:
                            if (vm.Character.SpellSlotsEighthLevelCurrent > 0)
                            {
                                vm.Character.SpellSlotsEighthLevelCurrent--;
                                FixSpellSlotChecked(level, vm.Character.SpellSlotsEighthLevelCurrent, vm.Character.SpellSlotsEighthLevel);
                            }
                            break;
                    }
                    if (characterDb != null && vm != null)
                        await characterDb.SaveCharacterAsync(vm.Character);
                }
            }
        }

        private async void OnSpellSlotAddClicked(object? sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is string levelParam)
            {
                if (int.TryParse(levelParam, out int level) && vm != null)
                {
                    switch (level)
                    {
                        case 1:
                            if (vm.Character.SpellSlotsFirstLevelCurrent < vm.Character.SpellSlotsFirstLevel)
                            {
                                vm.Character.SpellSlotsFirstLevelCurrent++;
                                FixSpellSlotChecked(level, vm.Character.SpellSlotsFirstLevelCurrent, vm.Character.SpellSlotsFirstLevel);
                            }
                            break;
                        case 2:
                            if (vm.Character.SpellSlotsSecondLevelCurrent < vm.Character.SpellSlotsSecondLevel)
                            {
                                vm.Character.SpellSlotsSecondLevelCurrent++;
                                FixSpellSlotChecked(level, vm.Character.SpellSlotsSecondLevelCurrent, vm.Character.SpellSlotsSecondLevel);
                            }
                            break;
                        case 3:
                            if (vm.Character.SpellSlotsThirdLevelCurrent < vm.Character.SpellSlotsThirdLevel)
                            {
                                vm.Character.SpellSlotsThirdLevelCurrent++;
                                FixSpellSlotChecked(level, vm.Character.SpellSlotsThirdLevelCurrent, vm.Character.SpellSlotsThirdLevel);
                            }
                            break;
                        case 4:
                            if (vm.Character.SpellSlotsFourthLevelCurrent < vm.Character.SpellSlotsFourthLevel)
                            {
                                vm.Character.SpellSlotsFourthLevelCurrent++;
                                FixSpellSlotChecked(level, vm.Character.SpellSlotsFourthLevelCurrent, vm.Character.SpellSlotsFourthLevel);
                            }
                            break;
                        case 5:
                            if (vm.Character.SpellSlotsFifthLevelCurrent < vm.Character.SpellSlotsFifthLevel)
                            {
                                vm.Character.SpellSlotsFifthLevelCurrent++;
                                FixSpellSlotChecked(level, vm.Character.SpellSlotsFifthLevelCurrent, vm.Character.SpellSlotsFifthLevel);
                            }
                            break;
                        case 6:
                            if (vm.Character.SpellSlotsSixthLevelCurrent < vm.Character.SpellSlotsSixthLevel)
                            {
                                vm.Character.SpellSlotsSixthLevelCurrent++;
                                FixSpellSlotChecked(level, vm.Character.SpellSlotsSixthLevelCurrent, vm.Character.SpellSlotsSixthLevel);
                            }
                            break;
                        case 7:
                            if (vm.Character.SpellSlotsSeventhLevelCurrent < vm.Character.SpellSlotsSeventhLevel)
                            {
                                vm.Character.SpellSlotsSeventhLevelCurrent++;
                                FixSpellSlotChecked(level, vm.Character.SpellSlotsSeventhLevelCurrent, vm.Character.SpellSlotsSeventhLevel);
                            }
                            break;
                        case 8:
                            if (vm.Character.SpellSlotsEighthLevelCurrent < vm.Character.SpellSlotsEighthLevel)
                            {
                                vm.Character.SpellSlotsEighthLevelCurrent++;
                                FixSpellSlotChecked(level, vm.Character.SpellSlotsEighthLevelCurrent, vm.Character.SpellSlotsEighthLevel);
                            }
                            break;
                    }
                    if (characterDb != null && vm != null)
                        await characterDb.SaveCharacterAsync(vm.Character);
                }
            }
        }

        private async void OnTempMaxHPClicked(object? sender, EventArgs e)
        {
            if (vm != null)
            {
                string? initialValue = vm.Character.TempMaxHP != 0 ? vm.Character.TempMaxHP.ToString() : null;
                string result = await DisplayPromptAsync(null, "Enter temporary max HP:", initialValue: initialValue, keyboard: Keyboard.Numeric);
                if (int.TryParse(result, out int tempMaxHP))
                {
                    vm.Character.TempMaxHP = tempMaxHP;
                    if (vm.Character.CurrentHP > vm.Character.TotalMaxHP)
                        vm.Character.CurrentHP = vm.Character.TotalMaxHP;
                    await characterDb.SaveCharacterAsync(vm.Character);
                }
            }
        }
        private async void OnTempCurrentHPClicked(object? sender, EventArgs e)
        {
            if (vm != null)
            {
                string? initialValue = vm.Character.TempCurrentHP > 0 ? vm.Character.TempCurrentHP.ToString() : null;
                string result = await DisplayPromptAsync(null, "Enter temporary HP:", initialValue: initialValue, keyboard: Keyboard.Numeric);
                if (int.TryParse(result, out int tempCurrentHP))
                {
                    if (tempCurrentHP < 0)
                        tempCurrentHP = 0;
                    vm.Character.TempCurrentHP = tempCurrentHP;
                    await characterDb.SaveCharacterAsync(vm.Character);
                }
            }
        }
        private async void OnCurrentHPRemoveClicked(object? sender, EventArgs e)
        {
            if (vm != null)
            {
                string result = await DisplayPromptAsync(null, "Enter HP loss:", keyboard: Keyboard.Numeric);
                if (int.TryParse(result, out int hp))
                {
                    if (hp < 0)
                        hp = 0;
                    if (hp > vm.Character.TempCurrentHP)
                    {
                        var remainingHP = hp - vm.Character.TempCurrentHP;
                        vm.Character.TempCurrentHP = 0;
                        vm.Character.CurrentHP = Math.Max(0, vm.Character.CurrentHP - remainingHP);
                    }
                    else
                    {
                        vm.Character.TempCurrentHP -= hp;
                    }
                    await characterDb.SaveCharacterAsync(vm.Character);
                }
            }
        }
        private async void OnCurrentHPAddClicked(object? sender, EventArgs e)
        {
            if (vm != null)
            {
                string result = await DisplayPromptAsync(null, "Enter HP gain:", keyboard: Keyboard.Numeric);
                if (int.TryParse(result, out int hp))
                {
                    if (hp < 0)
                        hp = 0;
                    if (vm.Character.CurrentHP + hp > vm.Character.TotalMaxHP)
                        vm.Character.CurrentHP = vm.Character.TotalMaxHP;
                    else
                        vm.Character.CurrentHP += hp;
                    await characterDb.SaveCharacterAsync(vm.Character);
                }
            }
        }

        private async void OnSpellsCollapseMenuClicked(object? sender, EventArgs e)
        {
            if (vm != null)
            {
                foreach (var spell in vm.Spells)
                {
                    spell.IsExpanded = false;
                }
            }
        }
        private async void OnSpellsExpandMenuClicked(object? sender, EventArgs e)
        {
            if (vm != null)
            {
                foreach (var spell in vm.Spells)
                {
                    spell.IsExpanded = true;
                }
                var spellsView = this.FindByName<CollectionView>("SpellsView");
            }
        }

        private async void OnAbilitiesAllMenuClicked(object? sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("AbilityAllPage");
        }
        private async void OnAbilitiesCollapseMenuClicked(object? sender, EventArgs e)
        {
            if (vm != null)
            {
                foreach (var ability in vm.Abilities)
                {
                    ability.IsExpanded = false;
                }
            }
        }
        private async void OnAbilitiesExpandMenuClicked(object? sender, EventArgs e)
        {
            if (vm != null)
            {
                foreach (var ability in vm.Abilities)
                {
                    ability.IsExpanded = true;
                }
                var abilitiesView = this.FindByName<CollectionView>("AbilitiesView");
            }
        }

        private async void OnFeatsAllMenuClicked(object? sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("FeatAllPage");
        }
        private async void OnFeatsCollapseMenuClicked(object? sender, EventArgs e)
        {
            if (vm != null)
            {
                foreach (var feat in vm.Feats)
                {
                    feat.IsExpanded = false;
                }
            }
        }
        private async void OnFeatsExpandMenuClicked(object? sender, EventArgs e)
        {
            if (vm != null)
            {
                foreach (var feat in vm.Feats)
                {
                    feat.IsExpanded = true;
                }
                var featsView = this.FindByName<CollectionView>("FeatsView");
            }
        }

        private async void OnTraitsAllMenuClicked(object? sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("TraitAllPage");
        }
        private async void OnTraitsCollapseMenuClicked(object? sender, EventArgs e)
        {
            if (vm != null)
            {
                foreach (var trait in vm.Traits)
                {
                    trait.IsExpanded = false;
                }
            }
        }
        private async void OnTraitsExpandMenuClicked(object? sender, EventArgs e)
        {
            if (vm != null)
            {
                foreach (var trait in vm.Traits)
                {
                    trait.IsExpanded = true;
                }
                var traitsView = this.FindByName<CollectionView>("TraitsView");
            }
        }

    }
}
