NAME=NonNullStack
COMMON=..\Common\AddRef.tex ..\Common\References.png ..\Common\Addref.png

$(NAME).pdf: $(NAME).tex $(COMMON)
	pdflatex $(NAME)
	pdflatex $(NAME)

view: $(NAME).pdf
	$(NAME).pdf


clean:
	del $(NAME).pdf
