# DiamondKata
Diamond Code Kata for davidwhitney / CodeDojos -  https://github.com/davidwhitney/CodeDojos/tree/master/Diamond%20Kata

My implementation for this kata goes beyond just creating a diamond. I tried to write the code in a way in which you could easily add an implementation for another shape.

Time and memory complexity have been considered. For example, in the instance of a diamond, I chose to use a dictionary so that the space requirement is around half what it would be if you stored every line, as we are only iterating up and down the dictionary to get the shape we want. There’s no need to store duplicate data. 

# 2 Branches - 2 Approaches

There are two branches with two different implementations. The mathematical approach calculates the number of spaces between the characters, however I initially thought that this is a less efficient method, because this approach is O(n) on the number of spaces.

The non mathematical approach copies the previous element and creates a substring of the spaces, and then adds the extra spaces for the next line. On research, I am under the impression that .SubString() is O(1), which means this section of the code scales better. What I will admit is this approach is not quite as clean and feels like it is more error prone. The flip side is that the alternative mathematical approach is easier to cover with more test cases.

# My Conclusion

I believe that despite the big O of the mathematical approach shows that it is less scalable, I believe it is the most suitable solution. Bearing in mind the use case and the fact we are using characters, a memory exception is so unlikely to occur. The mathematical approach is cleaner, safer, more testable, and therefore that would be my choice. Considering and balancing time and space complexity is not a wasted exercise however!
