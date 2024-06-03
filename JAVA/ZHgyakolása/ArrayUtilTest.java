// pac`kage array;
import static check.CheckThat.*;
import static org.junit.jupiter.api.Assertions.*;
import org.junit.jupiter.api.*;
import org.junit.jupiter.api.condition.*;
import org.junit.jupiter.api.extension.*;
import org.junit.jupiter.params.*;
import org.junit.jupiter.params.provider.*;
import check.*;

public class ArrayUtilTest{
    @Test 
    public void maxLength0(){
        array.util.ArrayUtil arr;
        arr = new array.util.ArrayUtil();
        int[] x = {};
        assertEquals(0,arr.max(x));
        assertEquals(0,arr.max2(x));
        assertEquals(0,arr.max3(x));
        assertEquals(0,arr.max4(x));
    }

    @ParameterizedTest(name="oneMemberArray")
    @CsvSource(textBlock="""
            0
            1
            5000
            -5
            """)
    @DisableIfHasBadStructure
    public void maxLength1(int value)
    {
        array.util.ArrayUtil arr= new array.util.ArrayUtil();
        int[] oneArr = {value};
        assertEquals(value, arr.max(oneArr));
        assertEquals(value, arr.max2(oneArr));
        assertEquals(value, arr.max3(oneArr));
        assertEquals(value, arr.max4(oneArr));
    }

    @ParameterizedTest(name="ArrOfTwoElement")
    @CsvSource(textBlock="""
            50, 5
            30, 3
            2, 1
            -1, -20
            """)
    @DisableIfHasBadStructure 
    public void maxLength2(int max, int min){
        int[] arr= {max,min};
        array.util.ArrayUtil au = new array.util.ArrayUtil();
        assertEquals(max, au.max(arr));
        assertEquals(max, au.max2(arr));
        assertEquals(max, au.max3(arr));
        assertEquals(max, au.max4(arr));
    }

    @Test 
    public void  minMaxLength0(){
        array.util.ArrayUtil arr = new array.util.ArrayUtil();
        int[] x = {0,0};
        assertArrayEquals(x,arr.minMax(x));
    }
    @ParameterizedTest(name="Las3f")
    @CsvSource(textBlock="""
            50,5
            5000,0
            66,5
            -9,-99
            """)
    @DisableIfHasBadStructure 
    public void minMaxLength2(int max, int min){
        int[] arr = {max,min};
        array.util.ArrayUtil au = new array.util.ArrayUtil();
        int[] res = {arr[1],arr[0]};
        assertArrayEquals(res, au.minMax(arr));
    }
}