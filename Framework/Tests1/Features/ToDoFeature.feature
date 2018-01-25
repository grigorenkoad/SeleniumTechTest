Feature: To Do Feature

Background: Open main page
	Given TO-DO Page is opened
	When I type "text" text into TO-DO Input on TO-DO Page

Scenario: Add TO-DO
	Then "text" TO-DO is displayed in TO-DO list
	And count of TO-DO should be equal "1"
	When I open Active tab
	Then "text" TO-DO is displayed in TO-DO list
	And count of TO-DO should be equal "0"

Scenario: Complete TO-DO
	When I complete "text" TO-DO
	Then count of TO-DO should be equal "0"
	When I open Active tab
	Then "text" TO-DO is missing in TO-DO list
	And count of TO-DO should be equal "0"
	When I open Completed tab
	Then "text" TO-DO is displayed in TO-DO list
	And count of TO-DO should be equal "0"
	And Clear Completed option is displayed

Scenario: Clear Completed TO-DO
	When I complete "text" TO-DO
	And clear compleded TO-DO
	Then "text" TO-DO is missing in TO-DO list

Scenario: Uncheck completed TO-DO
	When I complete "text" TO-DO
	And I open Active tab
	Then "text" TO-DO is missing in TO-DO list
	When I open Completed tab
	Then "text" TO-DO is displayed in TO-DO list
	When I uncomplete "text" TO-DO
	Then "text" TO-DO is missing in TO-DO list
	When I open Active tab
	Then "text" TO-DO is displayed in TO-DO list
