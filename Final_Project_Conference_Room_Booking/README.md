CONFERENCE ROOM BOOKINGS
SCENARIO
There is the need to create an app that will help manage multiple conference rooms.
Everyone can access the page and request a timeslot to use a room. The requests are sent to
the page administrator who chooses which requests are approved.
If a timeslot is approved, then it is no longer possible to request a reservation at the same
interval or at intervals that intersect with it.
For example, if Conference Room 1 is booked from 8 AM – 10 AM on September 1, 2022, it is not
possible to register a request for this room at 9 AM – 12 AM on September 1, 2022
If a request is not approved yet, the room is considered free, nonetheless the user is shown a
warning letting them know that there are other requests for that time slot as well.
For simplicity, the users are not required to be registered/logged in to make a reservation
request.
After a request is submitted, a registration code is given to the user, so that they can track the
booking status.
MAIN FUNCTIONALITIES
CONFERENCE ROOMS
Fields
Conference rooms
Id
Code
Maximum Capacity
BOOKINGS
Fields
Bookings
Id
Code
Number of People
Is Confirmed
Room Id
Start date
End date
Is deleted
The booking/reservation code should have a clear structure so that the user can recreate it
easily. For example:
Booking: Conference Room 1 is booked from 8 AM – 10:30 AM on September 1, 2022
Code: 20220901-0800-1000-C001
20220901 – date
0800 – start time
1030 – end time
C001 – conference room code
1. Create
a. Requests are performed by simple not logged in users
b. The start/end intervals, room id and number of people attending are required
c. It should not be allowed to book a room if the number of people attending
exceeds the maximum capacity.
2. View / List
a. Search the status of a booking (confirmed/pending)
b. The admin can also view the bookings for a selected date.
3. Update
a. Change the booking status, or delete it
b. NOTE! These operations are done by admin
4. Delete
a. A booking can be only soft deleted
b. NOTE! These operations are done by admin
RESERVATION HOLDERS
When a booking is created the person who creates needs to provide their personal
information at the same time. Hence, the admin can contact for further details.
Fields
Reservation Holders
Id
Id card number
Name
Surname
Email
Phone number
Notes
Booking Id
1. Create
a. Every booking should have the corresponding information about the
reservation holder
b. Only notes are optional
2. View / List
a. List/Search account holders by id card number/name/surname/booking
id/phone number
b. View the details of an account holder
c. NOTE! These operations are done by admin.
3. Update
a. NOTE! These operations are done by admin
4. Delete
a. An account holder can be only soft deleted
b. If they are deleted, the booking related to them should also be deleted.
c. NOTE! These operations are done by admin
USERS
To keep things simple the app will have only an admin user.
Fields
Users
Id
Name
Surname
Email
Is deleted
UP FOR A CHALLENGE?
If you feel like you are up for a challenge, consider the following additional features.
UNAVAILABILITY PERIODS
Consider the fact that the conference rooms will need to be maintained for e.g. to be
repainted, thoroughly cleaned etc. Users should not be able to reserve the rooms on these
dates.
Fields
Unavailability Periods
Id
Start date
End Date
1. Create
a. NOTE! These operations are done by admin.
2. View / List
a. View the list by selecting a certain month
b. NOTE! These operations are done by admin.
3. Update
a. NOTE! These operations are done by admin
4. Delete
a. A day period can be only soft deleted
b. If they are deleted, these days are considered available and users are free to
place requests.
c. NOTE! These operations are done by admin