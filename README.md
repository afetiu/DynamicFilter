# DynamicFilter

A lightweight .NET Core library for filtering data. Purposed to be used mostly to filter datatables

How To Use:

Filter() method is used as extension method for IEnumerable<> or IQueryable<> and accepts an object of type Filter as argument.

Filter class contains these properties:

- Skip (number of items to skip)

- Take (number of items to take)

- Items (a list of type Item)

Item class contains these properties:


- Property (name of property to be used for filtering)

- Value (value of the property)

- IsList (set to true when filtering a property which is a list, ex: User.Roles)

- Exclude (set to true if you want that property not to be used in filtering)

- Operator (equal, greater, less, etc)

Example:


// create Filter

Filter filter = new Filter
{
Skip = 0,
Take = 10
}


//create filter items

List<item> items = new List<item>();
	
items.add(new Item
{
Property = "LastName",
Value = "Smith",
Operator = OperatorName.Equal
});


//use filtering for an entity coming from database
FilteredData<User> users = db.Users.Filter(filter);
	
//get data and count

var rows = users.Data;

var count = users.Count; 


