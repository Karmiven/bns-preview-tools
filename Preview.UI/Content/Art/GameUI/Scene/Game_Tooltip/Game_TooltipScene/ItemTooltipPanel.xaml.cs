﻿using System.Windows;
using System.Windows.Controls;
using CUE4Parse.BNS.Assets.Exports;
using Xylia.Preview.Common.Extension;
using Xylia.Preview.Data.Helpers;
using Xylia.Preview.Data.Models;
using Xylia.Preview.Data.Models.Sequence;
using Xylia.Preview.UI.Controls;
using Xylia.Preview.UI.Converters;
using Xylia.Preview.UI.ViewModels;

namespace Xylia.Preview.UI.GameUI.Scene.Game_Tooltip;
public partial class ItemTooltipPanel
{
	#region Constructors
	public ItemTooltipPanel()
	{
		InitializeComponent();
	}
	#endregion

	#region Methods
	protected override void OnLoaded(RoutedEventArgs e)
	{
		if (DataContext is not Item record) return;

		#region Decompose 
		DecomposeDescription_Title.Visibility = Visibility.Collapsed;

		var pages = DecomposePage.LoadFrom(record.DecomposeInfo);
		if (pages.Count > 0)
		{
			DecomposeDescription_Title.Visibility = Visibility.Visible;
			DecomposeDescription_Title.String.LabelText = (record is Item.Grocery ? "UI.ItemTooltip.RandomboxPreview.Title" : "UI.ItemTooltip.Decompose.Title").GetText();

			var page = pages[0];
			page.Update(DecomposeDescription.Children);
		}
		#endregion

		ItemIcon.ExpansionComponentList["BackgroundImage"]?.SetValue(record.BackIcon);
		ItemIcon.ExpansionComponentList["IconImage"]?.SetValue(record.FrontIcon);
		ItemIcon.ExpansionComponentList["UnusableImage"]?.SetValue(null);
		ItemIcon.ExpansionComponentList["Grade_Image"]?.SetValue(null);
		ItemIcon.ExpansionComponentList["CanSaleItem"]?.SetValue(record.CanSaleItemImage);
		ItemIcon.InvalidateVisual();

		ItemDescription7.String.LabelText = record.Attributes["description7"].GetText() + 
			string.Join("<br/>", record.ItemCombat.SelectNotNull(x => x.Instance));

		#region Combat Holder
		Combat_Holder.Visibility = Visibility.Collapsed;
		if (record.RandomOptionGroupId != 0)
		{
			var Job = UserSettings.Default.Job;
			var ItemRandomOptionGroup = FileCache.Data.Provider.GetTable<ItemRandomOptionGroup>()[record.RandomOptionGroupId + ((long)Job << 32)];

			// title
			Combat_Holder.Children.Clear();
			Combat_Holder.Children.Add(Combat_Holder_Title);
			Combat_Holder_Title.String.LabelText = string.Format("{0} ({1}-{2})", ItemRandomOptionGroup.SkillTrainByItemListTitle,
				ItemRandomOptionGroup.SkillTrainByItemListSelectMin, ItemRandomOptionGroup.SkillTrainByItemListSelectMax);

			foreach (var SkillTrainByItemList in ItemRandomOptionGroup.SkillTrainByItemList.SelectNotNull(x => x.Instance))
			{
				SkillTrainByItemList.ChangeSet.ForEach(SkillTrainByItem =>
				{
					var box = new HorizontalBox();
					Combat_Holder.Children.Add(box);
					LayoutData.SetAnchors(box, FLayoutData.Anchor.Full);


					var description = new BnsCustomLabelWidget();
					description.String.LabelText = UserSettings.Default.UseDebugMode ? SkillTrainByItem.Description2 : SkillTrainByItem.Description.GetText();

					box.Children.Add(description);
				});
			}

			Combat_Holder.VerticalTree = Combat_Holder.Children.OfType<UIElement>().ToList();
			Combat_Holder.Visibility = Visibility.Visible;
		}
		#endregion
	}
	#endregion


	#region Helpers
	internal sealed class DecomposePage
	{
		#region Fields
		public JobSeq Job;

		public Reward? DecomposeReward { get; private set; }

		public Tuple<Item, short>? OpenItem { get; private set; }
		#endregion

		#region Methods
		public static List<DecomposePage> LoadFrom(ItemDecomposeInfo info)
		{
			var pages = new List<DecomposePage>();

			#region reward
			for (int index = 0; index < info.DecomposeReward.Length; index++)
			{
				var reward = info.DecomposeReward[index];
				var item2 = info.Decompose_By_Item2[index];
				if (reward is null) continue;

				pages.Add(new DecomposePage() { DecomposeReward = reward, OpenItem = item2 });
			}
			#endregion

			#region job reward
			var group_job = info.DecomposeJobRewards
				.Where(x => x.Value is not null)
				.Select(x => new DecomposePage() { Job = x.Key, DecomposeReward = x.Value, });

			if (group_job.Any())
			{
				// combine data according to cell num
				//int num = group_job.Sum(group => group.Preview.Count);
				//if (num >= 30) pages.AddRange(group_job);
				//else pages.Add(new DecomposePage()
				//{
				//	Job = JobSeq.JobNone,
				//	DecomposeReward = group_job.FirstOrDefault().DecomposeReward,
				//	OpenItem = info.Job_Decompose_By_Item2.FirstOrDefault(),
				//	Preview = group_job.SelectMany(group => group.Preview).ToList(),
				//});
			}
			#endregion

			return pages;
		}

		public void Update(UIElementCollection collection)
		{
			ArgumentNullException.ThrowIfNull(DecomposeReward);
			collection.Clear();

			DecomposeReward.FixedItem.ForEach(x => x.Instance, (item, i) =>
			{
				var min = DecomposeReward.FixedItemMin[i];
				var max = DecomposeReward.FixedItemMax[i];

				collection.Add(new BnsCustomLabelWidget()
				{
					Arguments = new TextArguments { [1] = item, [2] = min, [3] = max },
					String = new StringProperty()
					{
						LabelText = (min == max ? min == 1 ?
						"UI.ItemTooltip.RandomboxPreview.Fixed" :
						"UI.ItemTooltip.RandomboxPreview.Fixed.Min" :
						"UI.ItemTooltip.RandomboxPreview.Fixed.MinMax").GetText(),
					}
				});
			});
			DecomposeReward.SelectedItem.ForEach(x => x.Instance, (item, i) =>
			{
				var count = DecomposeReward.SelectedItemCount[i];
				collection.Add(new BnsCustomLabelWidget()
				{
					Arguments = new TextArguments { [1] = item, [2] = count },
					String = new StringProperty() { LabelText = "UI.ItemTooltip.RandomboxPreview.Selected".GetText() }
				});
			});
			DecomposeReward.RandomItem.ForEach(x => x.Instance, (item, i) =>
			{
				collection.Add(new BnsCustomLabelWidget()
				{
					Arguments = new TextArguments { [1] = item },
					String = new StringProperty() { LabelText = "UI.ItemTooltip.RandomboxPreview.Random".GetText() }
				});
			});
		}
		#endregion
	}
	#endregion
}