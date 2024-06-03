// package famous.sequence;
// import static check.CheckThat.*;
// import static org.junit.jupiter.api.Assertions.*;
// import org.junit.jupiter.api.*;
// import org.junit.jupiter.api.condition.*;
// import org.junit.jupiter.api.extension.*;
// import org.junit.jupiter.params.*;
// import org.junit.jupiter.params.provider.*;
// import check.*;
// import famous.sequence.*;
// public class TriangularNumbersTest {
//         public int getTriangularNumber(int n) {
//             if(n < 0) 
//                 return 0;
//             return ((n*(n+1))/ 2);
//         }
    
//         @Test
//         public void testGetHour() {
//             assertEquals(15, getTriangularNumber(5));
//         }
    
//         @ParameterizedTest(name = "{2}:{3} vs {4}:{5} ⟹ {0}:{1}")
//         @CsvSource(textBlock = """
//             6, 21
//             3, 6
//             5, 15
//         """)
//         @DisableIfHasBadStructure
//         public void paramTest(int nr, int ecpected){
//             assertEquals(ecpected, getTriangularNumber(nr));
//         }
// }


// package famous.sequence;

// import static org.junit.jupiter.api.Assertions.assertEquals;

// import org.junit.jupiter.api.Test;
// import org.junit.jupiter.params.ParameterizedTest;
// import org.junit.jupiter.params.provider.CsvSource;

// public class TriangularNumbersTest {
//     public int getTriangularNumber(int n) {
//         if (n < 0) 
//             return 0;
//         return (n * (n + 1)) / 2;
//     }

//     @Test
//     public void testGetTriangularNumber() {
//         assertEquals(15, getTriangularNumber(5));
//     }

//     @ParameterizedTest(name = "{0} → {1}")
//     @CsvSource({ "6, 21", "3, 6", "5, 15" })
//     public void paramTest(int nr, int expected) {
//         assertEquals(expected, getTriangularNumber(nr));
//     }
// }











package famous.sequence;

import org.junit.jupiter.api.Test;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.CsvSource;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class TriangularNumbersTest {
    @ParameterizedTest(name = "Triangular number of {0} is {1}")
    @CsvSource(textBlock = """
        0, 0
        1, 1
        3, 6
        5, 15
        -1, 0
        -5, 0
    """)
    public void testGetTriangularNumber(int nr, int expected) {
        assertEquals(expected, TriangularNumbers.getTriangularNumber(nr));
    }

    @ParameterizedTest(name = "Triangular number alternative of {0} is {1}")
    @CsvSource(textBlock = """
        0, 0
        1, 1
        3, 6
        5, 15
        -1, 0
        -5, 0
    """)
    public void testGetTriangularNumberAlternative(int nr, int expected) {
        assertEquals(expected, TriangularNumbers.getTriangularNumberAlternative(nr));
    }

    @Test
    public void testGetTriangularNumberWrongExpected() {
        assertEquals(10, TriangularNumbers.getTriangularNumber(4));
    }
}
