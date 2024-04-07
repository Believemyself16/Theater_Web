<template>
  <div>
    <v-toolbar app height="70">
      <v-app-bar-nav-icon class="black--text" @click="drawer = !drawer">
      </v-app-bar-nav-icon>
      <v-icon class="mx-2 black--text">mdi-post-outline</v-icon>
      <v-toolbar-title class="font-weight-medium black--text">
        MyBlog
      </v-toolbar-title>
      <v-spacer></v-spacer>
      <v-responsive max-width="600">
        <v-text-field
          class="pl-16"
          placeholder="Search"
          hint="What do you want to search for?"
          append-icon="mdi-magnify"
        >
        </v-text-field>
      </v-responsive>
    </v-toolbar>

    <v-navigation-drawer temporary app v-model="drawer">
      <v-list>
        <v-list-item
          v-for="link in links"
          :key="link.text"
          router
          :to="link.route"
        >
          <v-list-item-action>
            <v-icon>{{ link.icon }}</v-icon>
          </v-list-item-action>
          <v-list-content class="">{{ link.text }}</v-list-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
  </div>
</template>

<script>
export default {
  name: "Navbar",
  data() {
    return {
      drawer: false,
      links: [
        { icon: "mdi-newspaper", text: "Homepage", route: "/" },
        { icon: "mdi-account", text: "My account", route: "/account" },
      ],
    };
  },
};
</script>
