# Api_Project

Controller Name: RegisterUser

Functional Requirement:

Handle business rules for requestor and donor registration.
Pass requestor or donor details to the database layer for database addition operations.
Method Definitions:

GetDonorDetails
Parameters: None
Description: Retrieves the donor details from the database layer.
Return: Donor details (presumably in a suitable data structure).

GetRequestorDetails
Parameters: None
Description: Retrieves the requestor details from the database layer.
Return: Requestor details (presumably in a suitable data structure).

AddDonorDetails
Parameters:
DonorId (string): Donor's unique identifier.
FirstName (string): Donor's first name.
LastName (string): Donor's last name.
DateOfBirth (string): Donor's date of birth.
Emailid (string): Donor's email address.
Contactno (string): Donor's contact number.
Bloodgroup (string): Donor's blood group.
Address (string): Donor's address.
Gender (string): Donor's gender.
Description: Sends the donor details to the database layer to perform a database addition operation.
Return: None (void).


AddRequestorDetails
Parameters:
RequestorId (string): Requestor's unique identifier.
FirstName (string): Requestor's first name.
LastName (string): Requestor's last name.
DateOfBirth (string): Requestor's date of birth.
Email (string): Requestor's email address.
Contact no (string): Requestor's contact number.
Bloodgroup (string): Requestor's blood group.
Address (string): Requestor's address.
Gender (string): Requestor's gender.
Description: Sends the requestor details to the database layer to perform a database addition operation.
Return: None (void).

AuthenticateRequestor
Parameters:
Requestorname (string): Requestor's username.
Password (string): Requestor's password.
RequestorId (out string): Output parameter to store the authenticated requestor's unique identifier.
Description: Performs authentication based on the requestor name and password entered and returns the requestor's unique identifier and a message indicating success or failure.
Return: None (void).

AuthenticateDonor
Parameters:
Donorname (string): Donor's username.
Password (string): Donor's password.
DonorId (out string): Output parameter to store the authenticated donor's unique identifier.
Description: Performs authentication based on the donor name and password entered and returns the donor's unique identifier and a message indicating success or failure.
Return: None (void).

