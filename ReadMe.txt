User guildline:

There are 3 Module in API.
1)	Restocking Plan
2)	Clever Price Trick
3)	Inventory Magic

Each Module have 2 API call
1) 	Direct add json Data and API will give you result.
2)	User upload .json file and API will give you result.



Calculation of Module
1)	Restocking Plan
	As we have unlimited entry of each Product and there can be unlimited product, we follow below step.
	1)	Group Every product by their Ids.
	2)	Find avarage 'quantitySold' value for each product,
	3)	This value will be suggest value for RecommendedQuantity for that product.
	For example
	consider following input
		[
			{"productID": 123, "quantitySold": 10, "timestamp": "2024-06-01T10:00:00"},
			{"productID": 123, "quantitySold": 10, "timestamp": "2024-06-02T10:00:00"},
			{"productID": 123, "quantitySold": 10, "timestamp": "2024-06-03T10:00:00"},
			{"productID": 123, "quantitySold": 10, "timestamp": "2024-06-04T10:00:00"},
			{"productID": 123, "quantitySold": 10, "timestamp": "2024-06-05T10:00:00"},
			{"productID": 123, "quantitySold": 10, "timestamp": "2024-06-06T10:00:00"},
			{"productID": 123, "quantitySold": 10, "timestamp": "2024-06-07T10:00:00"},
			{"productID": 123, "quantitySold": 10, "timestamp": "2024-06-08T10:00:00"},
			{"productID": 123, "quantitySold": 10, "timestamp": "2024-06-09T10:00:00"},
			{"productID": 123, "quantitySold": 10, "timestamp": "2024-06-10T10:00:00"}
		]
		
		Here product 123 has 10 entry and each entry has 10 quantitySold for for this product avarage RecommendedQuantity will be 10
		
2)	Clever Price Tric
	Here we have unlimited number of product with price and trend. we follow below step.
	1)	For each product we check its 'trend'
	2)	There may be three (we assume) option for trend i) 'increasing' ii) 'decreasing' iii) 'nochange'
	3) 	If trend increasing then we incress price to 10%, if trend decreasing we decress price to 10%, and if tread nochange then we don't change product price.
	
	For example
	Consider following input
		[{"productID": 123, "price": 10, "trend": "increasing"},
		{"productID": 456, "price": 20, "trend": "decreasing"},
		{"productID": 789, "price": 15, "trend": "nochange"}]

		So for Product 123 UpdatedPrice will be 11
		for product 456 UpdatedPrice will be 18
		for product 789 UpdatedPrice will be 15
		

3)	Inventory Magic
	Here we have unlimited product with popularityScore, shelfLife, we follow below steps
	1)	for each Product first we check its shelfLife, if shelfLife is less then 30 we put counter to -0.1
	2)	then we add that counter with popularityScore, 
	3) 	We add that much % value from current stock,
	
	
	for example
	Consider following input
	[{"productID": 123, "currentStock": 100, "popularityScore": 0.8, "shelfLife": 31},
	{"productID": 456, "currentStock": 150, "popularityScore": 0.7, "shelfLife": 20},
	{"productID": 789, "currentStock": 200, "popularityScore": 1.2, "shelfLife": 26}]
	
	for product 123 shelfLife > 30 so RecommendedAdjustment will be 90
	for product 456 shelflife < 30 so RecommendedAdjustment will be 90
	for product 789 shelfLife < 30 so RecommendedAdjustment will be 220