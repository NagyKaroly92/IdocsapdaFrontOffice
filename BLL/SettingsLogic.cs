using DAL;
using DAL.DbSets;
using LinqToDB;

namespace BLL
{
    public static class SettingsLogic
    {
        public static string GetSetting(string name)
        {
            using (var context = new AppDbContext())
            {
                return context.Settings.FirstOrDefault(_ => _.Name == name).Value;
            }
        }
        public static void SetSetting(string name, string value)
        {
            using (var context = new AppDbContext())
            {
                context.Settings.FirstOrDefault(_ => _.Name == name).Value = value;
                context.SaveChanges();
            }
        }
        public static void SetLastRow()
        {
            using (var context = new AppDbContext())
            {
                var maxId = context.Game.Where(_ => _.IsEnglish == 0).Max(_ => _.Id).ToString();
                var setting = context.Settings.FirstOrDefault(_ => _.Name == "LastRow");

                context.Settings.Remove(context.Settings.FirstOrDefault(_ => _.Name == "LastRow"));

                if (setting != null)
                {
                    context.Settings.Add(new Settings { Name = "LastRow", Value = maxId });
                }
                else
                {
                    // Ha nincs ilyen bejegyzés, újat hozhatsz létre
                    context.Settings.Add(new Settings { Name = "LastRow", Value = maxId });
                }

                context.SaveChanges();
            }
        }
        public static void SetEnglishLastRow()
        {
            using (var context = new AppDbContext())
            {
                var maxId = context.Game.Where(_ => _.IsEnglish == 1).Max(_ => _.Id).ToString();
                var setting = context.Settings.FirstOrDefault(_ => _.Name == "EnglishLastRow");

                context.Settings.Remove(context.Settings.FirstOrDefault(_ => _.Name == "EnglishLastRow"));

                if (setting != null)
                {
                    context.Settings.Add(new Settings { Name = "EnglishLastRow", Value = maxId });
                }
                else
                {
                    // Ha nincs ilyen bejegyzés, újat hozhatsz létre
                    context.Settings.Add(new Settings { Name = "EnglishLastRow", Value = maxId });
                }

                context.SaveChanges();
            }
        }
    }
}
