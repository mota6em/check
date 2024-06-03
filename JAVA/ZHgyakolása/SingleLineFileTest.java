// package text.*;
import static check.CheckThat.*;
import static org.junit.jupiter.api.Assertions.*;
import org.junit.jupiter.api.*;
import org.junit.jupiter.api.condition.*;
import org.junit.jupiter.api.extension.*;
import org.junit.jupiter.params.*;
import org.junit.jupiter.params.provider.*;
import check.*;

import java.io.IOException;
import java.io.BufferedReader;
import java.io.FileReader;

public class SingleLineFileTest{
    @Test
    public void testEmpty(){
        String file_path = "";
        
        try(FileReader f = new FileReader(file_path);BufferedReader br = new BufferedReader(f);){

            try{
                text.to.numbers.SingleLineFile.addNumbers(file_path);
                fail("Expected IllegalArgumentException to be thrown");
            }
            catch(IOException e){
                fail("Expeted IllegelArgumentException to be thrown");
            }
            catch(IllegalArgumentException e){
                assertEquals("Empty file", e.getMessage());
            }
        }
        catch(IOException e){

        }
    }
    @Test 
    public void notExistFile(){
        String file_path = "notExistent.txt";
        
        try{
            text.to.numbers.SingleLineFile.addNumbers(file_path);
            fail("Expected IOExeption to be thrown");
        }
        catch(IOException e){
            // fail("Unexpected IOException: " + e.getMessage());
        }
    }
    @Test 
    public void ExistFile(){
        String  file_path = "text.txt";
        // FileReader file = new FileReader(file_path);
        // BufferedReader v = new BufferedReader(file);
        try{
            int n = text.to.numbers.SingleLineFile.addNumbers(file_path); // what is the problem here?????
            assertEquals(22,n);
        }
        catch(IOException e)
        {
            fail("Unexpected IOException: " + e.getMessage());
        }
    }
}