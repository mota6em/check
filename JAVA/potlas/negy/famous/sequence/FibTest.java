package famous.sequence;

import static check.CheckThat.*;
import static org.junit.jupiter.api.Assertions.*;
import org.junit.jupiter.api.*;
import org.junit.jupiter.api.condition.*;
import org.junit.jupiter.api.extension.*;
import org.junit.jupiter.params.*;
import org.junit.jupiter.params.provider.*;
import check.*;
import famous.sequence.*;

public class FibTest {
    @ParameterizedTest(name="noName")
    @CsvSource(textBlock="""
            2, 3
            56, 3
            2, 3
            56, 3
            2, 3
            56, 3
            2, 3
            56, 3
            2, 3
            56, 3
            """)
    @DisableIfHasBadStructure
    public void t(int r){
        assertEquals(3,3);
    }
    @ParameterizedTest(name = "if true then")
    @CsvSource(textBlock = """
            2, 3, 5
            22, 33, 334
            """)
    @DisableIfHasBadStructure
    public void paramTest2(int nr, int tr, int dr){
        assertEquals(Fibonacci.test(dr)+Fibonacci.test(dr), Fibonacci.test(dr)+Fibonacci.test(dr));
    }
    @Test 
    public void mytest(){
        assertEquals(4, Fibonacci.test(3));
    }
    @Test
    public void testGetHour() {
        assertEquals(8, Fibonacci.fib(6));
    }
    @Test
    public void testGetHour1() {
        assertEquals(8, Fibonacci.fib(6));
    }
    @ParameterizedTest(name = "is that true")
    @CsvSource(textBlock = """
        2, 1, 0
        2, 0, 1
        4, 2, 3
        4, 3, 2
        3, 1, 2
    """)
    @DisableIfHasBadStructure
    public void paramTest(int n, int k , int l){
        assertEquals(Fibonacci.fib(n), Fibonacci.fib(k)+Fibonacci.fib(l));
    }
    @ParameterizedTest(name = "{2}:{3} vs {4}:{5} ⟹ {0}:{1}")
    @CsvSource(textBlock = """
        3, 2
        6, 8
        7, 13
    """)
    @DisableIfHasBadStructure
    public void paramTest(int nr, int ecpected){
        assertEquals(ecpected, Fibonacci.fib(nr));
    }
    /*public void testEarlier(int expectedHour, int expectedMin, int hour1, int min1, int hour2, int min2) {
        Time time1 = new Time(hour1, min1);
        Time time2 = new Time(hour2, min2);

        assertEquals(expectedHour, time1.getEarlier(time2).getHour());
        assertEquals(expectedMin, time1.getEarlier(time2).getMin());

        assertEquals(expectedHour, time2.getEarlier(time1).getHour());
        assertEquals(expectedMin, time2.getEarlier(time1).getMin());
    }*/
}
