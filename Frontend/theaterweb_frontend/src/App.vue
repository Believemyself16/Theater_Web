<template>
  <v-app>
    <v-main>
      <Navbar />
      <router-view />
      <Footer />
    </v-main>
  </v-app>
</template>

<script>
import Navbar from "@/components/Navbar.vue";
import Footer from "@/components/Footer.vue";
export default {
  name: "App",
  components: {
    Navbar,
    Footer,
  },
  data: () => ({
    //
  }),
};
</script>

<style>
.v-application a {
  color: black;
}
</style>
