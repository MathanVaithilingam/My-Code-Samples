The DNA Sequence search Algorithm in c# - full, all possible match or first occurrence of nearest match within allowed mismatch character limit.
This can be further fine tuned.
Detail about DNA Sequence Search by MATHAN VAITHILINGAM
----------------------------------------------------------

Two different method :
----------------------

1. DnaSequenceMatchCheck - Return exact match result or all possible matches within mismatch limit.

2. DnaSequenceNearestMatchCheck - Return exact match result or first occurrence of nearest match within mismatch limit.

 ( * These methods can be moved to different class and make it reusable component)
 ( * This logic can be moved to SQL server as SQL CLR integration)



Run the application:
--------------------

1. Create C# Console application in Visual Studio.

2. Replace the console applicaton's "Program.cs" file content with attached "Program.cs" file content.

3. The "main()" method contains predefined DNA sequences.
    (Here 10 DNA sequences are defined. This can be replaced with database call/records).

4. Run the console application.

5. Enter search DNA sequence text.(Example : cactagtc )

6. Enter Number of mismatch character allowed and press enter. (Example: 2 )

7. It will start search from those predefined ten DNA sequences. (As I mentioned earlier we can write database call to get DNA sequence instead of predefined DNA sequences)

8. It will display two result set of above two methods for every DNA sequence item.

