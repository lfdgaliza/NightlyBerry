declare @article int = 1;
declare @en int = 1;

begin transaction;

    insert into category (ParentCategoryId, [Name]) values (null, 'Design Patterns')
    declare @designPatternsId int = SCOPE_IDENTITY()
    insert into category (ParentCategoryId, [Name]) values (@designPatternsId, 'creationalId')
    declare @creationalId int = SCOPE_IDENTITY()
    insert into category (ParentCategoryId, [Name]) values (@designPatternsId, 'Behavioral')
    declare @behavioralId int = SCOPE_IDENTITY()

	insert into Document (CategoryId, DocumentTypeId, CreatedAt) values (@creationalId, @article, GETDATE());
	insert into DocumentContent (LanguageId, DocumentId, Title, [Text]) values (@en, SCOPE_IDENTITY(), 'Abstract Factory', '# Abstract Factory
## UML Diagram
![UML Diagram](https://upload.wikimedia.org/wikipedia/commons/thumb/9/9d/Abstract_factory_UML.svg/677px-Abstract_factory_UML.svg.png)

> Img source: Wikipedia');

	insert into Document (CategoryId, DocumentTypeId, CreatedAt) values (@creationalId, @article, GETDATE());
	insert into DocumentContent (LanguageId, DocumentId, Title, [Text]) values (@en, SCOPE_IDENTITY(), 'Builder', '# Builder
\- Binf.  
\- Binf?  
\- Yes, Binf.  
\- Ok... But... What is Binf?  
\- Builder is not Fluent.

> I am so sorry about that...

I don''t know whether this expression was sometimes used or not for someone, but I put here to remind you that Builder and Fluent are different concepts. I did it because there is a lot of people that think that Builder and Fluent are the same, but, believe me, they are not.

**The Builder Pattern is about how can you construct a complex object.**  

Fluent, in another hand, is more like a Facade where you can join different objects in a more readable way. Like Entity Framework, for example! =)

So, in this source, you will find a complex solution for a simple problem for learning reasons. The goal here is to make you understand how to implement this pattern for when you need it in a real complex situation.

## UML Diagram
![UML](https://upload.wikimedia.org/wikipedia/commons/thumb/f/f3/Builder_UML_class_diagram.svg/1400px-Builder_UML_class_diagram.svg.png)

> Img source: Wikipedia

## SOLID
You can find this a great example of open/closed principle =)

## Players in this code
* Abstract Builder: IMobilePhoneBuilder
* Concrete Builders
    * IphoneXBuilder
    * Redmi3ProBuilder
    * S9Builder
* Director: MobilePhoneDirector
* Product: MobilePhone

## An image to remember
![Binf](/img/binf.png)
> Ok... I know... This is not exactly an image, but you''ve got the point.');

	insert into Document (CategoryId, DocumentTypeId) values (@behavioralId, @article);
	insert into DocumentContent (LanguageId, DocumentId, Title, [Text]) values (@en, SCOPE_IDENTITY(), 'Chain of Responsibility', '# Chain of Responsibility
You can use Chain of Responsibility in order to avoid a big amount of "ifs" in your code.  
It is good when you know that the number of operations can increase or even when you want to delegate parts of some complex job to some classes.  
It turns your code into a more clean, readable and organized one.

In the source code, you will find a solution for a calculator that can in the future has complex operations and solve math expressions, for example.

## Bonus
You can also find here an implementation of the Null Object Pattern. Take a look!

## UML
![UML](https://upload.wikimedia.org/wikipedia/commons/6/6a/W3sDesign_Chain_of_Responsibility_Design_Pattern_UML.jpg)

> Img source: Wikipedia');
	
commit;