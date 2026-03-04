import { useEffect, useState } from "react";
import reactLogo from "./assets/react.svg";
import viteLogo from "/vite.svg";
import "./App.css";
import type { EventDetails } from "./Models/EventDetails";
import { getAllEventDetailsAsync } from "./Service/EventDetailsService";
import type { EventBooking } from "./Models/EventBooking";

function App() {
  const [eventBookingDetails, setEventBookingDetails] = useState<
    EventBooking[] | any
  >(null);
  const [isLoading, setLoading] = useState<Boolean>(true);

  useEffect(() => {
    fetchEventDetails();
  }, []);

  const fetchEventDetails = async () => {
    const result = await getAllEventDetailsAsync();
    if (typeof result === "object") {
      setEventBookingDetails(result.data);
      setLoading(false);
    }
  };

  return (
    <>
      <ul>
        {eventBookingDetails && eventBookingDetails.length > 0 ? (
          eventBookingDetails.map((event: EventBooking, index: number) => (
            <li key={index}>
              <h1 className="font-red">{event.eventName || "Unnamed event"}</h1>
              {event.eventDetails?.length ? (
                event.eventDetails.map((detail: EventDetails) => (
                  <p key={detail.eventDetailsId} className="font-extrabold">
                    {detail.venue}
                  </p>
                ))
              ) : (
                <p>No details available</p>
              )}
            </li>
          ))
        ) : (
          <h1>No data</h1>
        )}
      </ul>
    </>
  );
}

export default App;
