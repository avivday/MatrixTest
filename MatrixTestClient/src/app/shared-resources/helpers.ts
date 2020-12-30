import AWN from "awesome-notifications"

import { throwError } from 'rxjs';

const globalOptions = {
  durations: {
    success: 2000,
    alert: 2000
  }
};

const notifier = new AWN(globalOptions)

export const handleError = (error) => {
  let errorMsg = '';

  if(error.error && error.error.innerException) {
    errorMsg += error.error.innerException.exceptionMessage;
  } else {
    errorMsg += error.error.message || "Something went wrong...";
  }

  notifier.alert(errorMsg);

  return throwError(error);
}
