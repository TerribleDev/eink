from PIL import Image
import time
from waveshare_epd import epd7in5_V2
def main():
    try:
        epd = epd7in5_V2.EPD()
        epd.init()

        # Load the bitmap image
        image = Image.open('axe.bmp')

        # Convert the image to 1-bit black and white
        image = image.convert('1') 

        # Display the image
        epd.display(epd.getbuffer(image))
        time.sleep(2)

        epd.sleep()

    except IOError as e:
        print(e)
        
    except KeyboardInterrupt:    
        print("ctrl + c:")
        epd7in5_V2.epdconfig.module_exit()
        exit()