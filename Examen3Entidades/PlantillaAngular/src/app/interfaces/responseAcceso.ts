export interface ResponseAcceso {
    statusCode: number;
    isSuccess: boolean;
    errorMessages: string[];
    result: { token: string };
  }
  