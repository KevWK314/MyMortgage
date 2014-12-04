using MyMortgage.Wpf.Specflow.Test.Context;

using TechTalk.SpecFlow;

namespace MyMortgage.Wpf.Specflow.Test.Steps
{
    [Binding]
    public class MainSteps
    {
        public MainContext _context = new MainContext();

        [Given(@"the mortgage server is down")]
        [When(@"the mortgage server is down")]
        public void GivenTheMortgageServerIsDown()
        {
            _context.Client.IsServiceOkResult = false;
            _context.Client.ThrowException = true;
        }

        [Given(@"the mortgage server is up")]
        [When(@"the mortgage server is up")]
        public void GivenTheMortgageServerIsUp()
        {
            _context.Client.IsServiceOkResult = true;
            _context.Client.ThrowException = false;
        }

        [When(@"I have started the application")]
        public void WhenIHaveStartedTheApplication()
        {
            _context.Initialise();
        }

        [Then(@"the MainViewModel should be")]
        public void ThenTheMainViewModelShouldBe(Table table)
        {
            var vmTable = _context.MainViewModel.ToTable();
            table.CompareTo(vmTable);
        }

        [When(@"I click refresh")]
        public void WhenIClickRefresh()
        {
            _context.MainViewModel.RefreshCommand.Execute(null);
        }
    }
}
