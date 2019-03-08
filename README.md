# You Have To Budget
> Inspired by [YNAB](https://www.youneedabudget.com/)

## CMU Final Project
> .NET Programming - [CS172](https://compass.centralmethodist.edu/ICS/Academics/CS/CS172__EX16/EXFA_2016_UNDG-CS172__EX16_-OA/)

## Getting Started 
  * If you're not already on VS2017 or higher, you need .NET 4.6.2
     > https://dotnet.microsoft.com/download/thank-you/net462-developer-pack
  * Take a look at Purpose and Logic if you have questions about use
  * Build and launch

If you have any problems with this app, please feel free to create an issue. I'll be happy to look into it.

---

<dl>
  <dt>Program Design</dt>
  <dd></dd>
  <dd>While this code is my own, this was intended to follow relatively strict guidelines enforced by the project expectations. 
  Please pardon some structure and design choices in which I might not normally make.</dd>
</dl>

---

#### Purpose and Logic
    This is a relatively simple applet designed to take a user's expenses and determine the approximate monthly
    cost of each of them combined. Users can also add monthly expenses for convenience. This is a great tool
    for quickly estimating what you would need to save monthly on expenses that occur annually such as isurance
    premiums, car service, dental visits, etc.

    It's currently limited to 10 entries for simplicity's sake. Users can enter '$' signs if they wish, but
    only one, as well as en-US numeric separators like '.' and ','. Other non-numeric characters are not accepted. 
    Issues with any entry are provided to the user through an on screen MessageBox and handled by clearing the field
    and processing the correctly filled out boxes.
    
---

<dl>
  <dt>Future State</dt>
  <dd></dd>
  <dd>This app is very limited and specific. The concept has merit and is easily extensible. A few areas I would improve:</dd>
</dl>

  * Incorporate income to determine how much is left over after expenses
  * ListBoxes with significantly more date ranges (ex: to calculate the cost of daily food expenses)
  * Expand this applet to be only a function of a larger aggregate of applets with similar functionality
  * Allow importing data from bank statements to automatically ask if certain purchases would be a good fit for this calculator
