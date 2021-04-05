using Guardian.Placeholder.Text.Generator.Web.Controllers;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Guardian.Text.Generator.Web.Tests
{
    public class WhenWebScraping
    {
        [SetUp]
        public static void Setup()
        {
            // Arrange
            HomeController.GetRandomPageNumber();
            var url = HomeController.BuildApiCall();
            // Act
            var actual = HomeController.SendGuardianRequest(url);
            HomeController.MapJsonToArticleModel(actual.Result);
            HomeController.SelectRandomSingleArticleFromCollection();
        }

        [Test]
        public void And_Values_Are_Stored_In_A_Collection()
        {
            //// Arrange
            var url = $"{HomeController._article.webUrl}";
            //// Act
            var result = HomeController.GetPageData(url);

            //// Assert
            Assert.IsTrue(result.Result.Count > 0);
        }

        [Test]
        [TestCase("< span class=\"css-1ohfkpt\"><span class=\"css-1ac5g5w\">S</span></span><span class=\"css-19t0h2c\">hould Arsenal, a club at a highly delicate stage of re-gearing, sign the mercurial, itinerant Philippe Coutinho? Should Paris Saint-Germain, three months into an impressively unified rebuild under Mauricio Pochettino, sign the exhilarating, weirdly doom-laden Philippe Coutinho? </span>")]
        [TestCase("According to a report this week in the Spanish online newspaper El Confidencial, Coutinho is one of four Barcelona players to be offered for sale in the summer.It is impossible to know these things with any certainty.Plans change all the time.What is certain is Coutinho�s time at Barcelona has been wild.This is a tale of three years, three managers, six trophies, �70m in the bank and the coveted No 1 spot in a poll of the club�s worst - ever big - money signings.All of this while playing quite well at times, never being obviously disruptive, and even making it into the Fifa team of < a href =\"https://www.theguardian.com/football/2018/jun/23/philippe-coutinho-brazil-world-cup-neymar\" title=\"\" data-link-name=\"in body link\" class=\"u-underline\">the 2018 World Cup</a>.")]
        [TestCase("Another key Coutinho ripple was Pochettino�s arrival in the Premier League, combined with <a href=\"https://www.theguardian.com/football/blog/2013/jan/19/southampton-sacking-nigel-adkins-folly\" title=\"\" data-link-name=\"in body link\" class=\"u-underline\">the defenestration of Nigel Adkins</a>. Nicola Cortese, Southampton�s executive chairman, had gone to Espanyol to scout Coutinho. He saw Pochettino striding about his touchline like a handsome bear with a particularly striking interest in football, and took the manager instead.")]
        [TestCase("So Coutinho <a href=\"https://www.theguardian.com/football/2013/jan/30/philippe-coutinho-liverpool-move-internazionale\" title=\"\" data-link-name=\"in body link\" class=\"u-underline\">washed up at Liverpool</a>, where he had four excellent years, but was of course there in Steven Gerrard�s eyeline at Anfield in April 2014, the alternative passing option to <a href=\"https://www.theguardian.com/football/2014/apr/27/liverpool-chelsea-premier-league-match-report\" title=\"\" data-link-name=\"in body link\" class=\"u-underline\">that fatal slip</a>; and there coming on a week later in the 78th minute at Crystal Palace <a href=\"https://www.theguardian.com/football/2014/may/05/crystal-palace-liverpool-premier-league-match-report\" title=\"\" data-link-name=\"in body link\" class=\"u-underline\">just before 3-0 turned to 3-3</a>. You could mention that Inter chewed though four managers in his time. Or that as <a href=\"https://www.theguardian.com/football/2018/jan/06/philippe-coutinho-join-barcelona-142m-deal-liverpool\" title=\"\" data-link-name=\"in body link\" class=\"u-underline\">Barcelona�s record signing</a> his best moment so far is scoring two for the opposition in <a href=\"https://www.theguardian.com/football/2020/aug/14/thomas-muller-leads-rout-as-bayern-munich-demolish-barcelona-8-2\" title=\"\" data-link-name=\"in body link\" class=\"u-underline\">an 8-2 thrashing of his own employers</a>. Or that he helped persuade Thiago Alc�ntara to go the other way to Liverpool, a world-class boomerang hex.")]
        [TestCase("<span class=\"css-1ohfkpt\"><span class=\"css-1ljoi60\">T</span></span><span class=\"css-19t0h2c\">o understand how much is on the line for <a href=\"https://www.theguardian.com/football/harry-kane\" data-component=\"auto-linked-tag\" data-link-name=\"in body link\">Harry Kane</a> this summer, it is worth laying everything out. He will captain England in what is in effect a home tournament and the prospect of lifting the weight imposed by five and a half decades of history is one that sets his eyes aglow. Kane believes he is at the height of his powers: he has never felt this good about his game so this would be the period, performing on those golden July evenings to a country that has rarely been more thirsty for a flush of euphoria, when a career�s loftiest ambitions bear fruit.</span>")]
        public void And_Copy_With_Html_Calls_RemoveHtmlCopy_Method(string html)
        {
            // Arrange
            // Act
            var actual = HomeController.CheckIfCopyContainsHtml(html);

            // Assert
            Assert.AreEqual(true, actual);
        }


        [Test]
        [TestCase(
    "< span class=\"css-1ohfkpt\"><span class=\"css-1ac5g5w\">S</span></span><span class=\"css-19t0h2c\">hould Arsenal, a club at a highly delicate stage of re-gearing, sign the mercurial, itinerant Philippe Coutinho? Should Paris Saint-Germain, three months into an impressively unified rebuild under Mauricio Pochettino, sign the exhilarating, weirdly doom-laden Philippe Coutinho? </span>",
    "Should Arsenal, a club at a highly delicate stage of re-gearing, sign the mercurial, itinerant Philippe Coutinho? Should Paris Saint-Germain, three months into an impressively unified rebuild under Mauricio Pochettino, sign the exhilarating, weirdly doom-laden Philippe Coutinho?")]
        [TestCase(
    "According to a report this week in the Spanish online newspaper El Confidencial, Coutinho is one of four Barcelona players to be offered for sale in the summer.It is impossible to know these things with any certainty.Plans change all the time.What is certain is Coutinho�s time at Barcelona has been wild.This is a tale of three years, three managers, six trophies, �70m in the bank and the coveted No 1 spot in a poll of the club�s worst - ever big - money signings.All of this while playing quite well at times, never being obviously disruptive, and even making it into the Fifa team of < a href =\"https://www.theguardian.com/football/2018/jun/23/philippe-coutinho-brazil-world-cup-neymar\" title=\"\" data-link-name=\"in body link\" class=\"u-underline\">the 2018 World Cup</a>.",
    "According to a report this week in the Spanish online newspaper El Confidencial, Coutinho is one of four Barcelona players to be offered for sale in the summer.It is impossible to know these things with any certainty.Plans change all the time.What is certain is Coutinho�s time at Barcelona has been wild.This is a tale of three years, three managers, six trophies, �70m in the bank and the coveted No 1 spot in a poll of the club�s worst - ever big - money signings.All of this while playing quite well at times, never being obviously disruptive, and even making it into the Fifa team of the 2018 World Cup.")]
        [TestCase("Another key Coutinho ripple was Pochettino�s arrival in the Premier League, combined with <a href=\"https://www.theguardian.com/football/blog/2013/jan/19/southampton-sacking-nigel-adkins-folly\" title=\"\" data-link-name=\"in body link\" class=\"u-underline\">the defenestration of Nigel Adkins</a>. Nicola Cortese, Southampton�s executive chairman, had gone to Espanyol to scout Coutinho. He saw Pochettino striding about his touchline like a handsome bear with a particularly striking interest in football, and took the manager instead.",
    "Another key Coutinho ripple was Pochettino�s arrival in the Premier League, combined with the defenestration of Nigel Adkins. Nicola Cortese, Southampton�s executive chairman, had gone to Espanyol to scout Coutinho. He saw Pochettino striding about his touchline like a handsome bear with a particularly striking interest in football, and took the manager instead.")]
        [TestCase(
    "So Coutinho <a href=\"https://www.theguardian.com/football/2013/jan/30/philippe-coutinho-liverpool-move-internazionale\" title=\"\" data-link-name=\"in body link\" class=\"u-underline\">washed up at Liverpool</a>, where he had four excellent years, but was of course there in Steven Gerrard�s eyeline at Anfield in April 2014, the alternative passing option to <a href=\"https://www.theguardian.com/football/2014/apr/27/liverpool-chelsea-premier-league-match-report\" title=\"\" data-link-name=\"in body link\" class=\"u-underline\">that fatal slip</a>; and there coming on a week later in the 78th minute at Crystal Palace <a href=\"https://www.theguardian.com/football/2014/may/05/crystal-palace-liverpool-premier-league-match-report\" title=\"\" data-link-name=\"in body link\" class=\"u-underline\">just before 3-0 turned to 3-3</a>. You could mention that Inter chewed though four managers in his time. Or that as <a href=\"https://www.theguardian.com/football/2018/jan/06/philippe-coutinho-join-barcelona-142m-deal-liverpool\" title=\"\" data-link-name=\"in body link\" class=\"u-underline\">Barcelona�s record signing</a> his best moment so far is scoring two for the opposition in <a href=\"https://www.theguardian.com/football/2020/aug/14/thomas-muller-leads-rout-as-bayern-munich-demolish-barcelona-8-2\" title=\"\" data-link-name=\"in body link\" class=\"u-underline\">an 8-2 thrashing of his own employers</a>. Or that he helped persuade Thiago Alc�ntara to go the other way to Liverpool, a world-class boomerang hex.",
    "So Coutinho washed up at Liverpool, where he had four excellent years, but was of course there in Steven Gerrard�s eyeline at Anfield in April 2014, the alternative passing option to that fatal slip; and there coming on a week later in the 78th minute at Crystal Palace just before 3-0 turned to 3-3. You could mention that Inter chewed though four managers in his time. Or that as Barcelona�s record signing his best moment so far is scoring two for the opposition in an 8-2 thrashing of his own employers. Or that he helped persuade Thiago Alc�ntara to go the other way to Liverpool, a world-class boomerang hex.")]
        [TestCase(
            "<span class=\"css-1ohfkpt\"><span class=\"css-1ljoi60\">T</span></span><span class=\"css-19t0h2c\">o understand how much is on the line for <a href=\"https://www.theguardian.com/football/harry-kane\" data-component=\"auto-linked-tag\" data-link-name=\"in body link\">Harry Kane</a> this summer, it is worth laying everything out. He will captain England in what is in effect a home tournament and the prospect of lifting the weight imposed by five and a half decades of history is one that sets his eyes aglow. Kane believes he is at the height of his powers: he has never felt this good about his game so this would be the period, performing on those golden July evenings to a country that has rarely been more thirsty for a flush of euphoria, when a career�s loftiest ambitions bear fruit.</span>",
            "To understand how much is on the line for Harry Kane this summer, it is worth laying everything out. He will captain England in what is in effect a home tournament and the prospect of lifting the weight imposed by five and a half decades of history is one that sets his eyes aglow. Kane believes he is at the height of his powers: he has never felt this good about his game so this would be the period, performing on those golden July evenings to a country that has rarely been more thirsty for a flush of euphoria, when a career�s loftiest ambitions bear fruit.")]
        
        public void And_Values_Are_Cleaned_Of_Any_Html(string htmlCopy, string expected)
        {
            // Arrange
            // Act
            var actual = HomeController.RemoveHtmlFromCopy(htmlCopy);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task And_Placeholder_Text_Is_Set_And_Matches_Character_Count_Request()
        {
            // Arrange
            var url = $"{HomeController._article.webUrl}";
            HomeController._characterCountRequest = 30;
            // Act
            var result = await HomeController.GetPageData(url);
            HomeController.BuildPlaceHolderText(result);
            // Assert
            Assert.AreEqual(HomeController._placeholderText.Length, HomeController._characterCountRequest);
            //Assert.AreEqual(HomeController._placeholderText, "Test");
        }
    }
}