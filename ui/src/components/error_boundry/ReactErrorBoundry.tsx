import { ErrorBoundary } from 'react-error-boundary';
import NotFound from '../../container/error_page/NotFound';

export default function ReactErrorBoundary(props) {
  return (
    <ErrorBoundary
      FallbackComponent={NotFound}
      onError={(error, errorInfo) => {
        // log the error
        console.log('Error caught!');
        console.error(error);
        console.error(errorInfo);

        // record the error in an APM tool...
      }}
    >
      {props.children}
    </ErrorBoundary>
  );
}
