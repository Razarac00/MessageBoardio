# MessageBoardio
message board web app home page should show the most recent messages     and also have a form to post a new message messages should be stored in a singleton service, provided to     the controller with dependency injection.     (no persistent/database required) should prevent CSRF.     do integration-test this. should include XSS vulnerability.     if i post a message with &lt;script>&lt;/script>, it should run when the page is next loaded.     integration-testing this is not required.
