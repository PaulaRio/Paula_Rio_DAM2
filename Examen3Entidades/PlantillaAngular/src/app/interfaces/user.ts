export interface User {
     statusCode: number;
     isSuccess: boolean;
     errorMessages: any[];
     result: Result;
 }
 
 export interface Result {
     token: string;
 }