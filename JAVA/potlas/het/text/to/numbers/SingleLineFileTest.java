package text.to.numbers;


import static check.CheckThat.*;
import static org.junit.jupiter.api.Assertions.*;
import org.junit.jupiter.api.*;
import org.junit.jupiter.api.condition.*;
import org.junit.jupiter.api.extension.*;
import org.junit.jupiter.params.*;
import org.junit.jupiter.params.provider.*;
import check.*;


public class SingleLineFileTest {

    @Test
    public void test1() {
        assertEquals("Empty file",SingleLineFile.addNumbers("empty.txt"));
    }
    @Test
    public void test2() {
        assertEquals("Empty file",SingleLineFile.addNumbers("non_numeric.txt"));
    }
    @Test
    public void test33() {
        assertEquals("Empty file",SingleLineFile.addNumbers("valid_file.txt"));
    }

    // @Test
    // public void testNonNumericValues() {
    //     try {
    //         SingleLineFile.addNumbers("non_numeric.txt");
    //         // It's expected to reach this line
    //     } catch (Exception e) {
    //         fail("Unexpected exception: " + e.getMessage());
    //     }
    // }

    // @Test
    // public void testValidFile() {
    //     int result = SingleLineFile.addNumbers("valid_file.txt");
    //     assertEquals(1 + 2 + 3 - 123, result);
    // }
}
