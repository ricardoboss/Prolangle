using Prolangle.Languages.Framework;

namespace Prolangle.Snippets.Ruby;

public class ArtistsControllerRubySnippet : IAttributedCodeSnippet
{
	public ILanguage Language => Languages.Ruby.Instance;
	public string Filename => "artists_controller.rb";
	public string Attribution => "https://medium.com/@gaidaescobar/build-a-very-basic-ruby-on-rails-app-e2ac88c47f8c";

	public string SourceCode =>
		"""
		class ArtistsController < ApplicationController

			def index
				@artists = Artist.all
			end

			def show
				@artist = Artist.find(params[:id])
			end

			def new
				@artist = Artist.new
			end

			def create
				@artist = Artist.create(artist_params)

				redirect_to @artist
			end

			def edit
				@artist = Artist.find(params[:id])
			end

			def update
				@artist = Artist.find(params[:id])
				@artist.update(artist_params)

				redirect_to @artist
			end

			def destroy
				@artist = Artist.find(params[:id])
				@artist.destroy

				redirect_to artists_path
			end

			private

			def artist_params
				params.require(:artist).permit(:name, :age,:experience)
			end
		end
		""";
}
