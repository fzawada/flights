flights
=======

I didn't want to touch the given code to focus on the task. However I do have some aditional thoughts:

1. There was a requirement to filter out those that "Have a segment with an arrival date before the departure date"
 --i wouldn't actually model it as such. I'd rather guard that at the aggregate/entity level so that such flights, which to seem invalid, could never come into existence. The cost of having potentially invalid entities is simply to high as one ends up checking for this error condition in many places whereas it should be checked in one place being the entity itself.

2. I also assumed segments are always in a chronological order. There's nothing in the code that prevents from creating flights with unordered segments -- I would add this in the Flight class.

3. I would add a guard clause preventing creation of a flight without any segments. To me, non-zero segments is what constitutes a valid flight.

4. As you can see I first created single rules and then added the specifications "engine". That is because I was fairly sure where I am going. Otherwise I'd start with the "engine" and creating a kind of walking skeleton for that task (being more top-down).

5. I am aware of some git-related mistakes like changing the format of commit messages for specifications or forgetting a file when commiting -- which could be solved by rebasing before pushing. I didn't want to mess with fixing that as that wasn't the point of the test. I also noticed some of these after pushing...

6. I could add more tests with different number of segments, had I a few more minutes.

7. I'm not sure in what context that filtering was to be used (before displaying, before accepting from external system) so I put the example usage in the test file.

