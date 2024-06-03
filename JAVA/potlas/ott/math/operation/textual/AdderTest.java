package math.operation.textual;
import static check.CheckThat.*;
import static org.junit.jupiter.api.Assertions.*;
import org.junit.jupiter.api.*;
import org.junit.jupiter.api.condition.*;
import org.junit.jupiter.api.extension.*;
import org.junit.jupiter.params.*;
import org.junit.jupiter.params.provider.*;
import check.*;
public class AdderTest {
    @Test
    public void wrongInput() {
        Adder adder = new Adder();
        assertEquals("Operands are not numbers", adder.addAsText("123", "abc"));
        assertEquals("Operands are not numbers", adder.addAsText("abc", "456"));
        assertEquals("Operands are not numbers", adder.addAsText("def", "ghi"));
    }

    @Test
    public void addZero() {
        Adder adder = new Adder();
        assertEquals("10", adder.addAsText("10", "0"));
        assertEquals("-5", adder.addAsText("-5", "0"));
        assertEquals("7.5", adder.addAsText("7.5", "0"));
    }

    @Test
    public void add() {
        Adder adder = new Adder();

        assertEquals("15", adder.addAsText("10", "5"));
        assertEquals("-3.5", adder.addAsText("-5", "1.5"));
        assertEquals("8.25", adder.addAsText("7.75", "0.5"));
    }

    @Test
    public void addCommutative() {
 
        Adder adder = new Adder();
        // Test for commutativity: a + b = b + a
        assertEquals(adder.addAsText("10", "5"), adder.addAsText("5", "10"));
        assertEquals(adder.addAsText("-5", "1.5"), adder.addAsText("1.5", "-5"));
        assertEquals(adder.addAsText("7.75", "0.5"), adder.addAsText("0.5", "7.75"));
    }
}